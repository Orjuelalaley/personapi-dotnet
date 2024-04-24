using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllTelefonosAsync();
        Task<Telefono> GetTelefonoByIdAsync(string num);
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Task UpdateTelefonoAsync(Telefono telefono);
        Task DeleteTelefonoAsync(string num);
        Task<bool> TelefonoExists(string num);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 77c2dece361294984559953a5844cd0097db210b
