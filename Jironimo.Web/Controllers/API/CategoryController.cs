using AutoMapper;
using Jironimo.Common.Abstract.Services;
using Jironimo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jironimo.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories());
            return Json(categories);
        }
    }     
}
