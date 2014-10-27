using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain;
using Fletnix.Domain.Services;
using Microsoft.AspNet.Identity;

namespace Fletnix.Web.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        // GET: Subscription/Start/1
        public async Task<ActionResult> Start(int id)
        {
            //Check if the current user already has a subscription.
            var subscription = await GetCurrentSubscriptionAsync();
            if (subscription != null && subscription.IsActive)
            {
                if (subscription.SubscriptionModel.Id == id)
                {
                    // Subscribing to the same subscription? No action needed.
                    return RedirectToAction("Index", "Watch");
                }

                RedirectToAction("Change", new { id });
            }

            var subscriptionModel = await _service.GetSubscriptionModelAsync(id);
            if (subscriptionModel == null)
            {
                // Wrong subscription model. Try again.
                return RedirectToAction("Index", "Home");
            }

            await _service.StartSubscriptionAsync(User.Identity.GetUserId(), subscriptionModel);
            return RedirectToAction("Index", "Watch");
        }

        private Task<Subscription> GetCurrentSubscriptionAsync()
        {
            var userId = User.Identity.GetUserId();
            return _service.GetCurrentSubscriptionAsync(userId);
        }
    }
}