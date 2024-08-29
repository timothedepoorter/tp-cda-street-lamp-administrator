using lampadaire.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lampadaire.Interface
{
    public interface IHoraireService
    {
        Task<IEnumerable<Horaire>> GetAllAsync();
        Task<Horaire> GetByIdAsync(string id);
        Task<Horaire> GetByInternalIdAsync(string internalId);
        Task<Horaire> CreateAsync(Horaire horaire);
        Task<bool> UpdateAsync(string id, Horaire horaireIn);
        Task<bool> DeleteAsync(string id);
    }
}