using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Fletnix.Domain;
using Fletnix.Domain.Repositories;
using Fletnix.Domain.Services;

namespace Fletnix.EF.Services
{
    public class CelebrityService : ICelebrityService
    {
        private readonly IBaseRepository<Celebrity> _repository;

        public CelebrityService(IBaseRepository<Celebrity> repository)
        {
            _repository = repository;
        }

        public Task<List<Celebrity>> GetAsync()
        {
            return _repository.Get().ToListAsync();
        }

        public Task<Celebrity> GetByIdAsync(int id)
        {
            return _repository.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task InsertAsync(Celebrity celebrity)
        {
            _repository.Add(celebrity);
            return _repository.SaveChangesAsync();
        }

        public Task UpdateAsync(Celebrity celebrity)
        {
            _repository.Update(celebrity);
            return _repository.SaveChangesAsync();
        }
    }
}