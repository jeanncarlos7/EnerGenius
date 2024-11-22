using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace EnerGenius.Models
{
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
