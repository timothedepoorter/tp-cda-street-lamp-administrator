using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
    public class Lampadaire
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; } 

        [BsonElement("numIdentite")]
        public string NumIdentite { get; set; }

        [BsonElement("puissanceLumiere")]
        public int PuissanceLumiere { get; set; }

        [BsonElement("isAllume")]
        public bool IsAllume { get; set; }

        [BsonElement("isKO")]
        public bool IsKO { get; set; }

        [BsonElement("GeoLocalisation")]
        public GeoLocation GeoLocalisation { get; set; }

        [BsonElement("DateDernierAllumage")]
        public DateTime DateDernierAllumage { get; set; }

        [BsonElement("horaireId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HoraireId { get; set; }

        [BsonElement("capteurs")]
        public List<Capteur> Capteurs { get; set; } 
    }

    public class GeoLocation
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("coordinates")]
        public double[] Coordinates { get; set; }
    }
}