using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class ApplicationDetailsController : Controller
    {
        private readonly IApplicationDetailsService _applicationDetailsService;
        private readonly IMapper _mapper;

        public ApplicationDetailsController(IApplicationDetailsService applicationDetailsService, IMapper mapper)
        {
            _applicationDetailsService = applicationDetailsService;
            _mapper = mapper;
        }

        // GET: ApplicationDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicationDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
