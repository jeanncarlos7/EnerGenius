using EnerGenius.HttpObjects.ContaConsumo;
using EnerGenius.Models;

namespace EnerGenius.Services.Interfaces
{
    public interface IContaConsumoService
    {
        Task<string> CreateContaConsumoAsync(ContaConsumoInsertRequest contaConsumoInsertRequest);
        Task DeleteContaConsumoAsync(string id);
        Task<ContaConsumo> GetContaConsumoByIdAsync(string id);
        Task UpdateContaConsumoAsync(ContaConsumoUpdateRequest contaConsumoUpdateRequest);


    }
}
