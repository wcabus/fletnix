using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain.Services;
using Microsoft.AspNet.Identity;

namespace Fletnix.Web.Controllers
{
    [Authorize]
    public class WatchController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public WatchController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        // GET: Watch
        public async Task<ActionResult> Index()
        {
            var subscription = await _subscriptionService.GetCurrentSubscriptionAsync(User.Identity.GetUserId());
            if (subscription == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}