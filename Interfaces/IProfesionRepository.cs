using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
<<<<<<< HEAD
}
=======
}
>>>>>>> 77c2dece361294984559953a5844cd0097db210b
