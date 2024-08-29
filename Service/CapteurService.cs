using lampadaire.Interface;
using lampadaire.Models;
using lampadaire.MongoDBConnection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace lampadaire.Service
{
    public class CapteurService : ICapteurService
    {
        private readonly IMongoCollection<Capteur> _capteurCollection;

        public CapteurService(IOptions<MongoDbSetting> settings, IMongoDatabase database)
        {
            _capteurCollection = database.GetCollection<Capteur>(settings.Value.CapteurCollectionName);
        }

        public async Task<List<Capteur>> GetAllCapteursAsync()
        {
            return await _capteurCollection.Find(capteur => true).ToListAsync();
        }

         public async Task<Capteur> GetCapteurByIdAsync(string id)
         {
             if (!ObjectId.TryParse(id, out var objectId))
             {
                 return null;
            }
        
            return await _capteurCollection.Find(capteur => capteur.Id == id).FirstOrDefaultAsync();
         }
    }
}