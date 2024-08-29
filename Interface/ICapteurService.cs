using lampadaire.Models;

namespace lampadaire.Interface
{
    public interface ICapteurService
    {
        Task<List<Capteur>> GetAllCapteursAsync();
        // Task<Capteur> GetCapteurByIdAsync(string id);
    }
}