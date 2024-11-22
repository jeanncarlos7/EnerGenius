using EnerGenius.Models;
using EnerGenius.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EnerGenius.Repositories
{
    public class UsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _collection;


        public UsuarioRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Usuario>("UsuarioCollection");
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _collection.InsertOneAsync(usuario);
        }

        public async Task<Usuario> GetUsuarioByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
           return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _collection.ReplaceOneAsync(x => x.Id == usuario.Id, usuario);
        }

        public async Task DeleteUsuarioAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
