using EnerGenius.HttpObjects.Usina;
using EnerGenius.Models;
using EnerGenius.Repositories;
using EnerGenius.Services.Interfaces;
using MongoDB.Bson;

namespace EnerGenius.Services
{
    public class UsinaService : IUsinaService
    {
        private readonly UsinaRepository _repository;
        private readonly UsuarioRepository _usuarioRepository;

        public UsinaService(UsinaRepository repository, UsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> CreateAsync(UsinaInsertRequest usinaInsertRequest)
        {
            var usina = new Usina
            {
                Endereco = usinaInsertRequest.Endereco,
                Latitude = usinaInsertRequest.Latitude,
                Longitude = usinaInsertRequest.Longitude,
                Nome = usinaInsertRequest.Nome,
                CapacidadeProducaoDiaria = usinaInsertRequest.CapacidadeProducaoDiaria,
                ReservaProducao = usinaInsertRequest.ReservaProducao,
                UsuarioId = usinaInsertRequest.UsuarioId,
                Id = ObjectId.GenerateNewId().ToString(),
            };

            // Se precisar, fazer as validações aqui
            await ValidaExistenciaDeUsuario(usina);

            await _repository.CreateUsinaAsync(usina);

            return usina.Id;
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteUsinaAsync(id);
        }

        public async Task<Usina> GetByIdAsync(string id)
        {
            return await _repository.GetUsinaByIdAsync(id);
        }

        public async Task UpdateAsync(UsinaUpdateRequest usinaUpdateRequest)
        {
            var usina = new Usina
            {
                Id = usinaUpdateRequest.Id,
                Endereco = usinaUpdateRequest.Endereco,
                Latitude = usinaUpdateRequest.Latitude,
                Longitude = usinaUpdateRequest.Longitude,
                Nome = usinaUpdateRequest.Nome,
                CapacidadeProducaoDiaria = usinaUpdateRequest.CapacidadeProducaoDiaria,
                ReservaProducao = usinaUpdateRequest.ReservaProducao,
                UsuarioId = usinaUpdateRequest.UsuarioId,
                Ativo = usinaUpdateRequest.Ativo
            };

            await ValidaExistenciaDeUsuario(usina);

            await _repository.UpdateUsinaAsync(usina);
        }

        private async Task ValidaExistenciaDeUsuario(Usina usina)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(usina.UsuarioId);

            if (usuario is null)
                throw new ArgumentException("Usuario não encontrado");
        }
    }
}
