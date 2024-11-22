using System.ComponentModel.DataAnnotations;

namespace EnerGenius.Models
{
    public class ContaConsumo : EntityBase
    {
        [Required]
        public float QuantidadeConsumo { get; set; }

        [Required]
        public DateTime DataConsumo { get; set; }

        [Required]
        public float Valor { get; set; }

        [Required]
        public string UsuarioId { get; set; } // Assume relacionamento com Usuario

    }
}
