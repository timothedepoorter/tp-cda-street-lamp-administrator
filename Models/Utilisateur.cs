

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
    public class Utilisateur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public int Identifiant { get; set; }
        public string MotDePasse { get; set; }
    }
}