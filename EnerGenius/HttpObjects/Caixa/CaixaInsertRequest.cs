using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.Caixa
{
    public class CaixaInsertRequest
    {

        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        public string UsuarioId { get; set; } // Assume relacionamento com Usuario

        public decimal? Saldo { get; set; }

        // string nome, DateTime dataCadastro, char ativo, int usuarioId, decimal? saldo

    }
}
