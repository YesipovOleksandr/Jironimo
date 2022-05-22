using Jironimo.Common.Models.Aplications;

namespace Jironimo.Web.Areas.Admin.Models.Categories
{
    public class CategoryCRUDViewModel
    {
        public CategoryCreateViewModel CategoryCreate { get; set; }
        public List<Category> Categories { get; set; }
    }
}
