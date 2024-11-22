using System.ComponentModel.DataAnnotations;

namespace EnerGenius.HttpObjects.Usina

{
    public class UsinaUpdateRequest : UsinaInsertRequest
    {

        [Key]
        public string Id { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

    }
}
