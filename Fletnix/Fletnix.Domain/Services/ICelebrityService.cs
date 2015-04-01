using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fletnix.Domain.Services
{
    public interface ICelebrityService
    {
        Task<List<Celebrity>> GetAsync();
        Task<Celebrity> GetByIdAsync(int id);

        Task InsertAsync(Celebrity celebrity);
        Task UpdateAsync(Celebrity celebrity);
    }
}