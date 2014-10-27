using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Fletnix.Domain.Services;
using Fletnix.Web.Models;
using Microsoft.AspNet.Identity;

namespace Fletnix.Web.Controllers
{
    [Authorize]
    public class WatchController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IVideoService _videoService;

        public WatchController(ISubscriptionService subscriptionService, IVideoService videoService)
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
            return View();
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
    }
}