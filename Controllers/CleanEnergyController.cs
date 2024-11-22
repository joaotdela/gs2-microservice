using Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using MongoDB.Driver;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleanEnergyController : ControllerBase
    {
        private readonly ICleanEnergyRepository _repository;

        public CleanEnergyController(ICleanEnergyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCleanEnergies()
        {
            var listaCleanEnergy = await _repository.ListarCleanEnergies();
            return StatusCode(200, listaCleanEnergy);
        }

        [HttpPost]
        public async Task<IActionResult> PostCleanEnergy([FromBody] CleanEnergy cleanEnergy)
        {
            await _repository.SalvarCleanEnergy(cleanEnergy);
            try
            {
                return StatusCode(201, "Criado com Sucesso");
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                return StatusCode(409, "Energia Limpa já registrada");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCleanEnergy(string id)
        {
            await _repository.RemoverCleanEnergy(id);
            return StatusCode(200, "Removido com Sucesso");
        }
        [HttpPut("(id")]
        public async Task<IActionResult> AtualizarCleanEnergy([FromBody] CleanEnergy cleanEnergy) {

             await _repository.AtualizarCleanEnergy(cleanEnergy);
            
            return StatusCode(200, "Atualizado com Sucesso");
        }
    }
}
