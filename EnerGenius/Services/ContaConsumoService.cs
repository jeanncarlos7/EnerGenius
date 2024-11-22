using EnerGenius.Extensions;
using EnerGenius.HttpObjects.Caixa;
using EnerGenius.HttpObjects.ContaConsumo;
using EnerGenius.Models;
using EnerGenius.Repositories;
using EnerGenius.Services.Interfaces;
using MongoDB.Bson;

namespace EnerGenius.Services
{
    public class ContaConsumoService : IContaConsumoService
    {
        private readonly ContaConsumoRepository _repository;
        private readonly UsuarioRepository _usuarioRepository;

        public ContaConsumoService(ContaConsumoRepository repository, UsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> CreateContaConsumoAsync(ContaConsumoInsertRequest contaConsumoInsertRequest)
        {
            var contaConsumo = new ContaConsumo
            {
                DataCadastro = DateTime.UtcNow,
                QuantidadeConsumo = contaConsumoInsertRequest.QuantidadeConsumo,
                Valor = contaConsumoInsertRequest.Valor,
                UsuarioId = contaConsumoInsertRequest.UsuarioId,
                DataConsumo = contaConsumoInsertRequest.DataConsumo,
                Id = ObjectId.GenerateNewId().ToString(),
            };

            ValidaContaConsumo(contaConsumo);

            // Valida a existencia do usuario
            await ValidaExistenciaDeUsuario(contaConsumo);

            await _repository.CreateContaConsumoAsync(contaConsumo);

            return contaConsumo.Id;
        }

        public async Task DeleteContaConsumoAsync(string id)
        {
            if (!id.IsValidMongoId())
                throw new ArgumentException("Id inválido");

            await _repository.DeleteContaConsumoAsync(id);
        }

        public async Task<ContaConsumo> GetContaConsumoByIdAsync(string id)
        {
            if (!id.IsValidMongoId())
                throw new ArgumentException("Id inválido");

            return await _repository.GetContaConsumoByIdAsync(id);
        }

        public async Task UpdateContaConsumoAsync(ContaConsumoUpdateRequest contaConsumoUpdateRequest)
        {
            var contaConsumo = new ContaConsumo
            {
                QuantidadeConsumo = contaConsumoUpdateRequest.QuantidadeConsumo,
                Valor = contaConsumoUpdateRequest.Valor,
                UsuarioId = contaConsumoUpdateRequest.UsuarioId,
                DataConsumo = contaConsumoUpdateRequest.DataConsumo,
                Id = contaConsumoUpdateRequest.Id,
                Ativo = contaConsumoUpdateRequest.Ativo,
               
            };

            if (!contaConsumoUpdateRequest.Id.IsValidMongoId())
                throw new ArgumentException("Id inválido");

            ValidaContaConsumo(contaConsumo);

            // Valida a existencia do usuario
            await ValidaExistenciaDeUsuario(contaConsumo);

            await _repository.UpdateContaConsumoAsync(contaConsumo);
        }


        private void ValidaContaConsumo(ContaConsumo contaConsumo)
        {

            if (contaConsumo.QuantidadeConsumo <= 0)
                throw new ArgumentException("Quantidade de consumo deve ser maior que zero");

            if (contaConsumo.DataConsumo <= DateTime.Today.AddDays(-30))
                throw new ArgumentException("Data de consumo precisa ser dos últimos 30 dias.");

            if (contaConsumo.DataConsumo > DateTime.Today)
                throw new ArgumentException($"O limite para a data de consumo é {DateTime.Today}.");

            if (string.IsNullOrWhiteSpace(contaConsumo.UsuarioId))
                throw new ArgumentException("Usuario deve ter um número válido");


        }

        private async Task ValidaExistenciaDeUsuario(ContaConsumo contaConsumo)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(contaConsumo.UsuarioId);

            if (usuario is null)
                throw new ArgumentException("Usuario não encontrado");
        }
    }
}
