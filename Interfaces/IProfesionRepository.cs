using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllProfesionsAsync();
        Task<Profesion> GetProfesionByIdAsync(int id);
        Task<Profesion> CreateProfesionAsync(Profesion profesion);
        Task UpdateProfesionAsync(Profesion profesion);
        Task DeleteProfesionAsync(int id);
        Task<bool> ProfesionExists(int id);
    }
}

