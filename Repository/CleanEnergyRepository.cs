using Models;
using MongoDB.Driver;

namespace Repository
{
    public class CleanEnergyRepository : ICleanEnergyRepository
    {
        public async Task<IEnumerable<CleanEnergy>> ListarCleanEnergies()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _database = client.GetDatabase("cleanEnergyDB");
            var retorno = _database.GetCollection<CleanEnergy>("cleanEnergy").Find(_ => true).ToListAsync();

            return await retorno;
        }

        public async Task SalvarCleanEnergy(CleanEnergy cleanEnergy)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _database = client.GetDatabase("cleanEnergyDB");
            await _database.GetCollection<CleanEnergy>("cleanEnergy").InsertOneAsync(cleanEnergy);
        }

        public async Task AtualizarCleanEnergy(CleanEnergy cleanEnergy)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _database = client.GetDatabase("cleanEnergyDB");
            await _database.GetCollection<CleanEnergy>("cleanEnergy").ReplaceOneAsync(x => x.Id == cleanEnergy.Id, cleanEnergy);
        }

        public async Task RemoverCleanEnergy(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var _database = client.GetDatabase("cleanEnergyDB");
            var collection = await _database.GetCollection<CleanEnergy>("cleanEnergy").DeleteOneAsync(x => x.Id.Equals(id));
        }
    }
}
