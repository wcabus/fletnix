using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fletnix.Domain.Services
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllAsync();

        Task<Genre> GetByIdAsync(int id);

        Task InsertAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(Genre genre);
    }
}