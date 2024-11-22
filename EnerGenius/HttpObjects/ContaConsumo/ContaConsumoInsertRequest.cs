using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.ContaConsumo
{
    public class ContaConsumoInsertRequest
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
