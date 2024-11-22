using System.ComponentModel.DataAnnotations;

namespace EnerGenius.Models
{
    public class Usuario : EntityBase
    {

        [Required, MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Pwd { get; set; }


        [Required, MaxLength(255)]
        public string Nome { get; set; }

    }
}
