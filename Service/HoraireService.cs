using lampadaire.Interface;
using lampadaire.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using lampadaire.MongoDBConnection;

namespace lampadaire.Service
{
    public class HoraireService : IHoraireService
    {
        private readonly IMongoCollection<Horaire> _horaireCollection;

        public HoraireService(IOptions<MongoDbSetting> settings, IMongoDatabase database)
        {
            _horaireCollection = database.GetCollection<Horaire>(settings.Value.HoraireCollectionName);
        }

        public async Task<IEnumerable<Horaire>> GetAllAsync()
        {
            return await _horaireCollection.Find(h => true).ToListAsync();
        }

        public async Task<Horaire> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return null;
            }

            return await _horaireCollection.Find(h => h.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Horaire> GetByInternalIdAsync(string internalId)
        {
            return await _horaireCollection.Find(h => h.InternalId == internalId).FirstOrDefaultAsync();
        }

        public async Task<Horaire> CreateAsync(Horaire horaire)
        {
            await _horaireCollection.InsertOneAsync(horaire);
            return horaire;
        }

        public async Task<bool> UpdateAsync(string id, Horaire horaireIn)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return false;
            }

            var updateResult = await _horaireCollection.ReplaceOneAsync(
                h => h.Id == id,
                horaireIn);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return false;
            }

            var deleteResult = await _horaireCollection.DeleteOneAsync(h => h.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }

}
