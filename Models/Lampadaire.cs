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
        public string CustomId { get; set; }  

        [BsonElement("numIdentite")]
        public string NumIdentite { get; set; }

        [BsonElement("puissanceLumiere")]
        public int PuissanceLumiere { get; set; }

        [BsonElement("isAllume")]
        public bool IsAllume { get; set; }

        [BsonElement("isKO")]
        public bool IsKO { get; set; }

        [BsonElement("GeoLocalisation")]
        public GeoLocalisation GeoLocalisation { get; set; }

        [BsonElement("DateDernierAllumage")]
        public DateTime DateDernierAllumage { get; set; }

        [BsonElement("horaireId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HoraireId { get; set; }  
    }

    public class GeoLocalisation
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("coordinates")]
        public double[] Coordinates { get; set; }
    }

}