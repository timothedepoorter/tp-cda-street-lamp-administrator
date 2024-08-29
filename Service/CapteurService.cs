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

        public async Task<Capteur> CreateCapteurAsync(Capteur capteur)
        {
            await _capteurCollection.InsertOneAsync(capteur);
            return capteur;
        }

        public async Task<bool> UpdateCapteurAsync(string id, Capteur capteurIn)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return false;
            }

            var updateResult = await _capteurCollection.ReplaceOneAsync(
                capteur => capteur.Id == id,
                capteurIn);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}