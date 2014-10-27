using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain.Services;
using Microsoft.AspNet.Identity;

namespace Fletnix.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public HomeController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // If this user has a subscription, redirect him/her to the dashboard instead
                var subscription = await _subscriptionService.GetCurrentSubscriptionAsync(User.Identity.GetUserId());
                if (subscription != null && subscription.IsActive)
                {
                    return RedirectToAction("Index", "Watch");
                }
            }

            ViewBag.Landing = "landing";
            return View(await _subscriptionService.GetSubscriptionModelsAsync());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}