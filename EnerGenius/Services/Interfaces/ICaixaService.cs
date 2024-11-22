using EnerGenius.HttpObjects.Caixa;
using EnerGenius.Models;

namespace EnerGenius.Services.Interfaces
{
    public interface ICaixaService
    {
        Task<string> CreateCaixaAsync(CaixaInsertRequest caixa);
        Task<Caixa> GetCaixaByIdAsync(string id);
        Task UpdateCaixaAsync(CaixaUpdateRequest caixaUpdateRequest);
        Task DeleteCaixaAsync(string id);
        void GetCaixaByIdAsync(int v);
    }
}
