using Jironimo.Common.Models.Aplications;

namespace Jironimo.Web.Areas.Admin.Models
{
    public class CategoryCRUDViewModel
    {
        public CategoryCreateViewModel Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
