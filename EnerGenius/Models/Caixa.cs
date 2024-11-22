using System.ComponentModel.DataAnnotations;

namespace EnerGenius.Models
{
    public class Caixa : EntityBase
    {

        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        public string UsuarioId { get; set; } // Assume relacionamento com Usuario

        public decimal? Saldo { get; set; }
    }
}
