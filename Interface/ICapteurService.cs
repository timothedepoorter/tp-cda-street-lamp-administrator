using lampadaire.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lampadaire.Interface
{
    public interface ICapteurService
    {
        Task<List<Capteur>> GetAllCapteursAsync();
        Task<Capteur> GetCapteurByIdAsync(string id);
        Task<Capteur> CreateCapteurAsync(Capteur capteur);
        Task<bool> UpdateCapteurAsync(string id, Capteur capteurIn);
    }
}