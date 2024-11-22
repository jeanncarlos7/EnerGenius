using EnerGenius.Extensions;
using EnerGenius.HttpObjects.Caixa;
using EnerGenius.Models;
using EnerGenius.Repositories;
using EnerGenius.Services.Interfaces;
using MongoDB.Bson;

namespace EnerGenius.Services
{
    public class CaixaService : ICaixaService
    {

        private readonly CaixaRepository _repository;
        private readonly UsuarioRepository _usuarioRepository;

        public CaixaService(CaixaRepository repository, UsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> CreateCaixaAsync(CaixaInsertRequest caixaInsertRequest)
        {
            var caixa = new Caixa
            {
                Nome = caixaInsertRequest.Nome,
                Ativo = true,
                DataCadastro = DateTime.UtcNow,
                UsuarioId = caixaInsertRequest.UsuarioId,
                Saldo = caixaInsertRequest.Saldo,
                Id = ObjectId.GenerateNewId().ToString(),
            };

            ValidaCaixa(caixa);

            // Valida a existencia do usuario
            await ValidaExistenciaDeUsuario(caixa);

            await _repository.CreateCaixaAsync(caixa);

            return caixa.Id;
        }

        public async Task DeleteCaixaAsync(string id)
        {
            await _repository.DeleteCaixaAsync(id);
        }

        public async Task<Caixa> GetCaixaByIdAsync(string id)
        {
            if (id.IsValidMongoId())
                return await _repository.GetCaixaByIdAsync(id);

            throw new ArgumentException("Id inválido");
        }

        public void GetCaixaByIdAsync(int v)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCaixaAsync(CaixaUpdateRequest caixaUpdateRequest)
        {
            var caixa = new Caixa
            {
                Id = caixaUpdateRequest.Id,
                Nome = caixaUpdateRequest.Nome,
                Ativo = true,
                UsuarioId = caixaUpdateRequest.UsuarioId,
                Saldo = caixaUpdateRequest.Saldo
            };

            ValidaCaixa(caixa);

            await _repository.UpdateCaixaAsync(caixa);
        }


        private void ValidaCaixa(Caixa caixa)
        {

            if (caixa.Nome.Length > 255)
                throw new ArgumentException("Nome deve ter no máximo 255 caracteres");

            if (string.IsNullOrWhiteSpace(caixa.Nome))
                throw new ArgumentException("Nome deve ser preenchido");

            if (string.IsNullOrWhiteSpace(caixa.UsuarioId))
                throw new ArgumentException("Usuario deve ter um número válido");

            if (caixa.Saldo < 0)
            {
                throw new ArgumentException("Saldo deve ser maior que zero");
            }
        }

        private async Task ValidaExistenciaDeUsuario(Caixa caixa)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(caixa.UsuarioId);

            if (usuario is null)
                throw new ArgumentException("Usuario não encontrado");
        }
    }
}
