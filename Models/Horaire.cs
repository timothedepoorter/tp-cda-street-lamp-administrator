using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
    public class Horaire
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }

        [BsonElement("saison")]
        public string Saison { get; set; }

        [BsonElement("heureDebut")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime HeureDebut { get; set; }

        [BsonElement("heureFin")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime HeureFin { get; set; }

        [BsonElement("dureeEclairage")]
        public int DureeEclairage { get; set; }
    }
}