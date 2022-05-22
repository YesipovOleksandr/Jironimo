using Jironimo.Web.ViewModels;

namespace Jironimo.Web.Areas.Admin.Models.Application
{
    public class ApplicationCRUDViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<ApplicationViewModel> ApplicationViews { get; set; }
        public ApplicationCreateViewModel ApplicationCreate { get; set; }
    }
}
