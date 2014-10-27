using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Fletnix.Domain;
using Fletnix.Domain.Repositories;
using Fletnix.Domain.Services;

namespace Fletnix.EF.Services
{
    public class VideoService : IVideoService
    {
        private readonly IBaseRepository<MediaStream> _mediaStreamRepository;
        private readonly IBaseRepository<TvShow> _tvShowRepository;

        public VideoService(IBaseRepository<MediaStream> mediaStreamRepository, IBaseRepository<TvShow> tvShowRepository)
        {
            _mediaStreamRepository = mediaStreamRepository;
            _tvShowRepository = tvShowRepository;
        }

        public Task<List<MediaStream>> GetMoviesAsync()
        {
            return _mediaStreamRepository.Get(m => m.MediaStreamTypeId == MediaStreamType.Movie).ToListAsync();
        }

        public Task<List<TvShow>> GetTvShowsAsync()
        {
            return _tvShowRepository.Get().ToListAsync();
        }

        public Task<MediaStream> GetMediaStreamAsync(int id)
        {
            return _mediaStreamRepository.Get(m => m.Id == id).
                Include(m => m.Genres).
                Include(m => m.Cast.Select(c => c.Celebrity)).
                Include(m => m.Cast.Select(c => c.MediaRole)).
                FirstOrDefaultAsync();
        }

        public Task<TvShow> GetTvShowAsync(int id)
        {
            return _tvShowRepository.Get(m => m.Id == id).
                Include(m => m.Genres).
                Include(m => m.Seasons.Select(s => s.Episodes)).
                Include(m => m.Seasons.Select(s => s.Episodes.Select(e => e.Genres))).
                Include(m => m.Seasons.Select(s => s.Episodes.Select(e => e.Cast.Select(c => c.Celebrity)))).
                Include(m => m.Seasons.Select(s => s.Episodes.Select(e => e.Cast.Select(c => c.MediaRole)))).
                FirstOrDefaultAsync();
        }
    }
}