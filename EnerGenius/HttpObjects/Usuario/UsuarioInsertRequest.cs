using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.Usuario
{
    public class UsuarioInsertRequest
    {
        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Pwd { get; set; }
    }
}
