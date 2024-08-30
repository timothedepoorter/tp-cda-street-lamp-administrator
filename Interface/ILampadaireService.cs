using lampadaire.Models;

namespace lampadaire.Interface
{
    public interface ILampadaireService
    {
        Task<List<Lampadaire>> GetAllLampadairesAsync();
        Task<Lampadaire> GetLampadaireByIdAsync(string id);
        Task<Lampadaire> CreateLampadaireAsync(Lampadaire lampadaire);
        Task<bool> UpdateLampadaireAsync(string id, Lampadaire lampadaireIn);
        Task<bool> DeleteAsync(string id);
    }
}