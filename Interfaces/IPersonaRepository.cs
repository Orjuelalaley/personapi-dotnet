using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllPersonasAsync();
        Task<Persona> GetPersonaByIdAsync(int cc);
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task<Persona> UpdatePersonaAsync(Persona persona);
        Task DeletePersonaAsync(int cc);
    }
}
