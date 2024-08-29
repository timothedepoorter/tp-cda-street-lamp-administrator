using lampadaire.Interface;
using lampadaire.Models;
using lampadaire.MongoDBConnection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace lampadaire.Service
{
    public class LampadaireService : ILampadaireService
    {
        private readonly IMongoCollection<Lampadaire> _lampadaireCollection;

        public LampadaireService(IOptions<MongoDbSetting> settings, IMongoDatabase database)
        {
            _lampadaireCollection = database.GetCollection<Lampadaire>(settings.Value.LampadaireCollectionName);
        }

        public async Task<List<Lampadaire>> GetAllLampadairesAsync()
        {
            return await _lampadaireCollection.Find(lampadaire => true).ToListAsync();
        }

        public async Task<Lampadaire> GetLampadaireByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return null;
            }

            return await _lampadaireCollection.Find(lampadaire => lampadaire.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Lampadaire> CreateLampadaireAsync(Lampadaire lampadaire)
        {
            await _lampadaireCollection.InsertOneAsync(lampadaire);
            return lampadaire;
        }

        public async Task<bool> UpdateLampadaireAsync(string id, Lampadaire lampadaireIn)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return false;
            }

            var updateResult = await _lampadaireCollection.ReplaceOneAsync(
                lampadaire => lampadaire.Id == id,
                lampadaireIn);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}