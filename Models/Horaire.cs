using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lampadaire.Models
{
        public class Horaire
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }

            public string Saison { get; set; }
            public TimeSpan HeureDebut { get; set; }
            public TimeSpan HeureFin { get; set; }
            public TimeSpan DureeEclairage { get; set; }
        }
}