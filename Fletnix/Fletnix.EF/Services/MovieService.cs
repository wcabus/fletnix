using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Fletnix.Domain;
using Fletnix.Domain.Caching;
using Fletnix.Domain.Repositories;
using Fletnix.Domain.Services;

namespace Fletnix.EF.Services
{
    public class MovieService : IMovieService
    {
        private readonly IBaseRepository<MediaStream> _mediaStreamRepository;
        private readonly IBaseRepository<Genre> _genreRepository;

        private readonly Cache _cache;

        public MovieService(
            IBaseRepository<MediaStream> mediaStreamRepository,
            IBaseRepository<Genre> genreRepository,
            Cache cache
            )
        {
            _mediaStreamRepository = mediaStreamRepository;
            _genreRepository = genreRepository;
            _cache = cache;
        }

        public Task<List<MediaStream>> GetMoviesAsync()
        {
            return _cache.GetAsync(CacheKeys.MovieList, 
                () => _mediaStreamRepository.Get(m => m.MediaStreamTypeId == MediaStreamType.Movie).ToListAsync());
        }

        public Task<MediaStream> GetMovieByIdAsync(int id)
        {
            return _cache.GetAsync(CacheKeys.MovieById(id),
                () => _mediaStreamRepository.Get(m => m.MediaStreamTypeId == MediaStreamType.Movie && m.Id == id).FirstOrDefaultAsync());
        }

        public Task<MediaStream> GetMovieAndGenresByIdAsync(int id)
        {
            return _cache.GetAsync(CacheKeys.MovieIncludingGenresById(id),
                () => _mediaStreamRepository.
                Get(m => m.MediaStreamTypeId == MediaStreamType.Movie && m.Id == id).
                Include(m => m.Genres).
                FirstOrDefaultAsync());
        }

        public Task<List<Genre>> GetGenresAsync()
        {
            return _cache.GetAsync(CacheKeys.Genres, 
                () => _genreRepository.Get().ToListAsync());
        }

        public Task InsertMovieAsync(MediaStream mediaStream)
        {
            _cache.Remove(CacheKeys.MovieList);
            _mediaStreamRepository.Add(mediaStream);
            return _mediaStreamRepository.SaveChangesAsync();
        }

        public Task UpdateMovieAsync(MediaStream mediaStream)
        {
            _cache.Remove(CacheKeys.MovieList);
            _cache.Remove(CacheKeys.MovieById(mediaStream.Id));
            _cache.Remove(CacheKeys.MovieIncludingGenresById(mediaStream.Id));

            _mediaStreamRepository.Update(mediaStream);
            return _mediaStreamRepository.SaveChangesAsync();
        }
    }
}