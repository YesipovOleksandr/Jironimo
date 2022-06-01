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
            CategoryCRUDViewModel categoryCRUDViewModel = new CategoryCRUDViewModel();
            categoryCRUDViewModel.Categories = _categoryService.GetCategories();
            return View("~/Areas/Admin/Views/Category/Category.cshtml", categoryCRUDViewModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryCRUDViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var category = _mapper.Map<Category>(model.CategoryCreate);
                    _categoryService.Create(category);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            model.Categories = _categoryService.GetCategories();
            return View("~/Areas/Admin/Views/Category/Category.cshtml", model);
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
