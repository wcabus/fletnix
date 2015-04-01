using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Fletnix.Domain.Services;
using Fletnix.Web.ApiModels;

namespace Fletnix.Web.ApiControllers
{
    [RoutePrefix("api/Movies")]
    public class MoviesController : ApiController
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [Route]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(
                (await _service.GetMoviesAsync()).Select(Movie.FromDomain)
            );
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var movie = await _service.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Movie.FromDomain(movie));
        }
    }
}
