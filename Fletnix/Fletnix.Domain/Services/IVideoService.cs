using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fletnix.Domain.Services
{
    public interface IVideoService
    {
        Task<List<MediaStream>> GetMoviesAsync();
        Task<List<TvShow>> GetTvShowsAsync();
        Task<MediaStream> GetMediaStreamAsync(int id);
        Task<TvShow> GetTvShowAsync(int id);
    }
}