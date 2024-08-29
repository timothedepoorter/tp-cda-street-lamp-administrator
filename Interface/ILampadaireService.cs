using lampadaire.Models;

namespace lampadaire.Interface
{
    public interface ILampadaireService
    {
        Task<List<Lampadaire>> GetAllLampadairesAsync();
        Task<Lampadaire> GetLampadaireByIdAsync(string id);
    }
}