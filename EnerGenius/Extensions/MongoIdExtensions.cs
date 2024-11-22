using MongoDB.Bson;

namespace EnerGenius.Extensions
{
    public static class MongoIdExtensions
    {
        /// <summary>
        /// Verifica se uma string é um ID válido do MongoDB.
        /// </summary>
        /// <param name="id">O ID a ser validado.</param>
        /// <returns>True se o ID for válido; caso contrário, False.</returns>
        public static bool IsValidMongoId(this string id)
        {
            return ObjectId.TryParse(id, out _);
        }
    }
}
