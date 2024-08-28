using lampadaire.Models;

namespace lampadaire.Service
{
    public interface ILampadaireService
    {
        Task<List<Lampadaire>> GetAllLampadairesAsync();
        Task<Lampadaire> GetLampadaireByIdAsync(string id);
    }
}