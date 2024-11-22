using EnerGenius.Models;
using EnerGenius.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace EnerGenius.Repositories
{
    public class CaixaRepository
    {
        private readonly IMongoCollection<Caixa> _collection;

        public CaixaRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Caixa>("CaixaCollection");
        }

        public async Task CreateCaixaAsync(Caixa caixa)
        {
            await _collection.InsertOneAsync(caixa);
        }

        public async Task<Caixa> GetCaixaByIdAsync(string id)
        {
            try
            {
                return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateCaixaAsync(Caixa caixa)
        {
            await _collection.ReplaceOneAsync(x => x.Id == caixa.Id, caixa);
        }
        public async Task DeleteCaixaAsync(string id)
        {

            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
