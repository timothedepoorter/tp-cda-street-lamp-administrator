using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
    
    public class Capteur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } 

        public int NumIdentite { get; set; }
        public string Type { get; set; }
        public bool IsActif { get; set; }
        public bool IsDetecting { get; set; }
        public bool IsKO { get; set; }
    }
}