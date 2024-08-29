using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
    public class Capteur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; } 

        [BsonElement("numIdentite")]
        public string NumIdentite { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("isActif")]
        public bool IsActif { get; set; }

        [BsonElement("isDetecting")]
        public bool IsDetecting { get; set; }

        [BsonElement("isKO")]
        public bool IsKO { get; set; }
    }
}