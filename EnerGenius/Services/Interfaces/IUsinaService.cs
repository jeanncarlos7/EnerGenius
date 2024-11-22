using EnerGenius.HttpObjects.Usina;
using EnerGenius.Models;

namespace EnerGenius.Services.Interfaces
{
    public interface IUsinaService
    {
        Task<string> CreateAsync(UsinaInsertRequest usinaInsertRequest);
        Task<Usina> GetByIdAsync(string id);
        Task UpdateAsync(UsinaUpdateRequest usinaUpdateRequest);
        Task DeleteAsync(string id);
    }
}
