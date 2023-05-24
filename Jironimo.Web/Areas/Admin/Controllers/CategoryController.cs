using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Common.Models.Aplications;
using Jironimo.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Jironimo.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetCategories();
            return View("~/Areas/Admin/Views/Category/Category.cshtml");
        }

        [HttpPost]
        public ActionResult Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var category = _mapper.Map<Category>(model);
                    _categoryService.Create(category);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Categories = _categoryService.GetCategories();
            return View("~/Areas/Admin/Views/Category/Category.cshtml", model);
        }

        public ActionResult Edit(Guid id)
        {
            var category = _categoryService.GetCategories().FirstOrDefault(x=>x.Id==id);
            return View("~/Areas/Admin/Views/Category/Edit.cshtml", category);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var category = _mapper.Map<Category>(model);
                    _categoryService.Update(category);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
