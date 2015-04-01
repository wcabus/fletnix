using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain;
using Fletnix.Domain.Services;

namespace Fletnix.Web.Areas.Administration.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _service;

        public GenresController(IGenreService service)
        {
            _service = service;
        }

        // GET: Administration/Genres
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetGenres()
        {
            var data = await _service.GetAllAsync();
            return Json(data.Select(
                g => new { id = g.Id, name = g.Name }
                ), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> SaveGenre(Genre g)
        {
            if (g.Id < 1)
            {
                await _service.InsertAsync(g);
            }
            else
            {
                await _service.UpdateAsync(g);
            }

            return Json(new { id = g.Id, name = g.Name });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            var genre = await _service.GetByIdAsync(id);
            if (genre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            await _service.DeleteAsync(genre);
            return Json(new { id = genre.Id, deleted = true });
        }
    }
}