using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.ContaConsumo
{
    public class ContaConsumoUpdateRequest : ContaConsumoInsertRequest
    {

        [Required]
        public string Id { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

    }
}
