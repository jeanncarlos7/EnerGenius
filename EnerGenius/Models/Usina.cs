using System.ComponentModel.DataAnnotations;

namespace EnerGenius.Models
{
    public class Usina : EntityBase
    {
        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        public string UsuarioId { get; set; } // Assume relacionamento com Usuario

        [MaxLength(512)]
        public string Endereco { get; set; }

        [MaxLength(15)]
        public string Latitude { get; set; }

        [MaxLength(15)]
        public string Longitude { get; set; }

        public float? CapacidadeProducaoDiaria { get; set; }
        public float ReservaProducao { get; set; }
    }
}
