using Jironimo.Web.ViewModels.ApplicationDetails;

namespace Jironimo.Web.Areas.Admin.Models.ApplicationDetails
{
    public class ApplicationDetailsCRUDViewModel
    {
        public List<Jironimo.Common.Models.Aplications.Application> Applications { get; set; }
        public ApplicationDetailsCreateViewModel ApplicationDetailsCreate { get; set; }

    }
}
