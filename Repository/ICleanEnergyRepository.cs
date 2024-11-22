using Models;

namespace Repository
{
    public interface ICleanEnergyRepository
    {
        Task<IEnumerable<CleanEnergy>> ListarCleanEnergies();
        Task SalvarCleanEnergy(CleanEnergy cleanEnergy);
        Task AtualizarCleanEnergy(CleanEnergy cleanEnergy);
        Task RemoverCleanEnergy(string id);
    }
}
