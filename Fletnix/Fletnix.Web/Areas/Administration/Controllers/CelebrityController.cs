using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain.Services;
using Fletnix.Web.Areas.Administration.Models;

namespace Fletnix.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class CelebrityController : Controller
    {
        private readonly ICelebrityService _repository;

        public CelebrityController(ICelebrityService repository)
        {
            _repository = repository;
        }

        // GET: Administration/Celebrity
        public async Task<ActionResult> Index()
        {
            var data = await _repository.GetAsync();
            return View(data);
        }

        // GET : Administration/Celebrity/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var celebrity = await _repository.GetByIdAsync(id);

            if (celebrity == null)
            {
                return RedirectToAction("Index");
            }

            return View(new CelebrityEditor
            {
                FirstName = celebrity.FirstName,
                LastName = celebrity.LastName,
                ImdbId = celebrity.ImdbId,
                ImageUri = celebrity.ImageUri
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CelebrityEditor celebrity)
        {
            if (ModelState.IsValid)
            {
                await _repository.InsertAsync(celebrity.ToDomain());

                return RedirectToAction("Index");
            }

            return View(celebrity);
        }

        // Edit: /Administration/Celebrity/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            var celebrity = await _repository.GetByIdAsync(id);

            if (celebrity == null)
            {
                return RedirectToAction("Index");
            }

            return View(new CelebrityEditor
            {
                Id = celebrity.Id,
                FirstName = celebrity.FirstName,
                LastName = celebrity.LastName,
                ImdbId = celebrity.ImdbId,
                ImageUri = celebrity.ImageUri
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CelebrityEditor celebrity)
        {
            if (ModelState.IsValid)
            {
                var domainCelebrity = celebrity.ToDomain();
                domainCelebrity.Id = id;
                
                await _repository.UpdateAsync(domainCelebrity);

                return RedirectToAction("Index");
            }

            return View(celebrity);
        }
    }
}