using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Fletnix.Domain;
using Fletnix.Domain.Repositories;

namespace Fletnix.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBaseRepository<SubscriptionModel> _subscriptionModelRepository;

        public HomeController(IBaseRepository<SubscriptionModel> subscriptionModelRepository)
        {
            _subscriptionModelRepository = subscriptionModelRepository;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _subscriptionModelRepository.Get().Include("Options.SubscriptionOptionTemplate").ToListAsync());
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