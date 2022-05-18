using Jironimo.Web.ViewModels;

namespace Jironimo.Web.Areas.Admin.Models
{
    public class ApplicationCRUDViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public ApplicationCreateViewModel ApplicationCreate { get; set; }
    }
}
