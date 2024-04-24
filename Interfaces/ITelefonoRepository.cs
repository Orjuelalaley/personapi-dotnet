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
}
