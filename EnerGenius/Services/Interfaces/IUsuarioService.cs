using EnerGenius.HttpObjects.Usuario;
using EnerGenius.Models;

namespace EnerGenius.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> CreateAsync(UsuarioInsertRequest usuarioInsertRequest);
        Task<Usuario> GetByIdAsync(string id);
        Task UpdateAsync(UsuarioUpdateRequest usuarioUpdateRequest);
        Task DeleteAsync(string id);
        Task<List<Usuario>> GetAsync();
    }
}
