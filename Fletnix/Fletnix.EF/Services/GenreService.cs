using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Fletnix.Domain;
using Fletnix.Domain.Caching;
using Fletnix.Domain.Repositories;
using Fletnix.Domain.Services;

namespace Fletnix.EF.Services
{
    public class GenreService : IGenreService
    {
        private readonly Cache _cache;
        private readonly IBaseRepository<Genre> _repository;

        public GenreService(Cache cache, IBaseRepository<Genre> repository)
        {
            _cache = cache;
            _repository = repository;
        }

        public Task<List<Genre>> GetAllAsync()
        {
            return _cache.GetAsync(CacheKeys.Genres, () => _repository.Get().ToListAsync());
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            return _cache.GetAsync(CacheKeys.GenreById(id), () => _repository.FirstOrDefaultAsync(g => g.Id == id));
        }

        public Task InsertAsync(Genre genre)
        {
            _cache.Remove(CacheKeys.Genres);

            _repository.Add(genre);
            return _repository.SaveChangesAsync();
        }

        public Task UpdateAsync(Genre genre)
        {
            _cache.Remove(CacheKeys.Genres);
            _cache.Remove(CacheKeys.GenreById(genre.Id));

            _repository.Update(genre);
            return _repository.SaveChangesAsync();
        }

        public Task DeleteAsync(Genre genre)
        {
            _cache.Remove(CacheKeys.Genres);
            _cache.Remove(CacheKeys.GenreById(genre.Id));

            _repository.Remove(genre);
            return _repository.SaveChangesAsync();
        }
    }
}