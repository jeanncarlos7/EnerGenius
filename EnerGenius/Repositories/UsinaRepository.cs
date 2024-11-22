using EnerGenius.Models;
using EnerGenius.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EnerGenius.Repositories
{
    public class UsinaRepository
    {
        private readonly IMongoCollection<Usina> _collection;

        public UsinaRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Usina>("UsinaCollection");
        }

        public async Task CreateUsinaAsync(Usina usina)
        {
            await _collection.InsertOneAsync(usina);
        }

        public async Task<Usina> GetUsinaByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateUsinaAsync(Usina usina)
        {
            await _collection.ReplaceOneAsync(x => x.Id == usina.Id, usina);
        }

        public async Task DeleteUsinaAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
