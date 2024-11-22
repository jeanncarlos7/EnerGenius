using EnerGenius.Extensions;
using EnerGenius.HttpObjects.Usuario;
using EnerGenius.Models;
using EnerGenius.Repositories;
using EnerGenius.Services.Interfaces;
using MongoDB.Bson;

namespace EnerGenius.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateAsync(UsuarioInsertRequest usuarioInsertRequest)
        {
            var usuario = new Usuario { 
                Email = usuarioInsertRequest.Email,
                Nome = usuarioInsertRequest.Nome,
                Pwd = usuarioInsertRequest.Pwd,
                Id = ObjectId.GenerateNewId().ToString(),
            };

            // Se precisar, fazer as validações aqui

            await _repository.CreateUsuarioAsync(usuario);

            return usuario.Id;
        }

        public async Task DeleteAsync(string id)
        {
            if (!id.IsValidMongoId())
                throw new ArgumentException("Id inválido");

            await _repository.DeleteUsuarioAsync(id);
        }

        public async Task<Usuario> GetByIdAsync(string id)
        {
            if (!id.IsValidMongoId())
                throw new ArgumentException("Id inválido");
            
            return await _repository.GetUsuarioByIdAsync(id);
        }

        public async Task<List<Usuario>> GetAsync()
        {
            return await _repository.GetUsuariosAsync();
        }

        public async Task UpdateAsync(UsuarioUpdateRequest usuarioUpdateRequest)
        {
            var usuario = new Usuario
            {
                Id = usuarioUpdateRequest.Id,
                Email = usuarioUpdateRequest.Email,
                Nome = usuarioUpdateRequest.Nome,
                Pwd = usuarioUpdateRequest.Pwd,
                Ativo = usuarioUpdateRequest.Ativo,
                
            };

            // Se precisar, fazer as validações aqui

            await _repository.UpdateUsuarioAsync(usuario);
        }
    }
}
