using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Repositories
{
    public interface IEstudioRepository
    {
        Task<IEnumerable<Estudio>> GetAllEstudiosAsync();
        Task<Estudio> GetEstudioByIdAsync(int idProf, int ccPer);
        Task<Estudio> CreateEstudioAsync(Estudio estudio);
        Task<Estudio> UpdateEstudioAsync(Estudio estudio);
        Task DeleteEstudioAsync(int idProf, int ccPer);
        Task<bool> EstudioExistsAsync(int idProf, int ccPer);
    }
}
