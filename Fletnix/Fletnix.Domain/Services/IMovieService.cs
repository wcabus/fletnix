using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fletnix.Domain.Services
{
    public interface IMovieService
    {
        Task<List<MediaStream>> GetMoviesAsync();
        Task<MediaStream> GetMovieByIdAsync(int id);
        Task<MediaStream> GetMovieAndGenresByIdAsync(int id);
        Task<List<Genre>> GetGenresAsync();

        Task InsertMovieAsync(MediaStream mediaStream);
        Task UpdateMovieAsync(MediaStream mediaStream);

        
    }
}