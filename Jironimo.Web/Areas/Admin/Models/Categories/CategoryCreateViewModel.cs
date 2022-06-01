using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models.Categories
{
    public class CategoryCreateViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
