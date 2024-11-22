using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.Caixa
{
    public class CaixaUpdateRequest : CaixaInsertRequest
    {

        [Required]
        public string Id { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

    }
}
