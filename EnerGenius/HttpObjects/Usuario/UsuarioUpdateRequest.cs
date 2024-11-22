using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.Usuario
{
    public class UsuarioUpdateRequest : UsuarioInsertRequest
    {
        [Required, Range(0, int.MaxValue)]
        public string Id { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;
    }
}
