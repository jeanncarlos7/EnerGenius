using EnerGenius.Models;
using EnerGenius.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EnerGenius.Repositories
{
    public class ContaConsumoRepository
    {
        private readonly IMongoCollection<ContaConsumo> _collection;

        public ContaConsumoRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<ContaConsumo>("ContaConsumoCollection");
        }

        public async Task CreateContaConsumoAsync(ContaConsumo contaConsumo)
        {
            await _collection.InsertOneAsync(contaConsumo);
        }

        public async Task<ContaConsumo> GetContaConsumoByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateContaConsumoAsync(ContaConsumo contaConsumo)
        {
            await _collection.ReplaceOneAsync(x => x.Id == contaConsumo.Id, contaConsumo);
        }

        public async Task DeleteContaConsumoAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
