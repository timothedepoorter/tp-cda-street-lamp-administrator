

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
    public class Utilisateur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("identifiant")]
        public string Identifiant { get; set; }

        [BsonElement("motDePasse")]
        public string MotDePasse { get; set; }

        [BsonElement("role")]
        public string Role { get; set; } = "user";  
    }
}