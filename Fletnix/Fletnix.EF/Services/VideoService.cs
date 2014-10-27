using System.Collections.Generic;
using System.Data.Entity;
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
    }
}