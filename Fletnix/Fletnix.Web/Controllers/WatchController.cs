using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain.Services;
using Fletnix.Web.Models;
using Fletnix.Web.Results;
using Microsoft.AspNet.Identity;

namespace Fletnix.Web.Controllers
{
    [Authorize]
    public class WatchController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IVideoService _videoService;

        public WatchController(
            ISubscriptionService subscriptionService, 
            IVideoService videoService)
        {
            _subscriptionService = subscriptionService;
            _videoService = videoService;
        }

        // GET: Watch
        public async Task<ActionResult> Index()
        {
            var subscription = await _subscriptionService.GetCurrentSubscriptionAsync(User.Identity.GetUserId());
            if (subscription == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var movies = await _videoService.GetMoviesAsync();
            var tvShows = await _videoService.GetTvShowsAsync();

            return View(new DashboardViewModel { Movies = movies, TvShows = tvShows });
        }

        [Route("~/Details/Movie/{id:int}")]
        public Task<ActionResult> MovieDetails(int id)
        {
            return Details(id);
        }

        [Route("~/Details/TvShow/{id:int}")]
        public async Task<ActionResult> TvShowDetails(int id)
        {
            var tvShow = await _videoService.GetTvShowAsync(id);
            return View(tvShow);
        }

        public async Task<ActionResult> Details(int id)
        {
            var mediaStream = await _videoService.GetMediaStreamAsync(id);
            if (mediaStream == null)
            {
                return RedirectToAction("Index");
            }

            return View("Details", mediaStream);
        }

        public async Task<ActionResult> Play(int id)
        {
            var mediaStream = await _videoService.GetMediaStreamForPlayerAsync(id);
            if (mediaStream == null)
            {
                return RedirectToAction("Index");
            }

            return View(mediaStream);
        }

        public ActionResult Stream(Guid id)
        {
            var path = Path.Combine("c:\\streams", id.ToString());
            if (!System.IO.File.Exists(path))
            {
                return null;
            }

            var fi = new FileInfo(path);
            return new RangeFilePathResult("video/mp4", fi.FullName, fi.LastWriteTimeUtc, fi.Length);
        }

        public ActionResult Index2()
        {
            return View("Knockout");
        }

        public async Task<ActionResult> GetMovies()
        {
            var movies = await _videoService.GetMoviesAsync();
            
            return Json(movies.Select(m => new
            {
                id = m.Id,
                title = m.Title,
                imageUri = m.ImageUri
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostAjax()
        {
            return Content("<h3>Success</h3>", "text/html");
        }
    }
}