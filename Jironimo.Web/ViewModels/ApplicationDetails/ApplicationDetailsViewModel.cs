namespace Jironimo.Web.ViewModels.ApplicationDetails
{
    public class ApplicationDetailsViewModel
    {
        public ApplicationViewModel Application { get; set; }
        public List<ApplicationViewModel> Applications { get; set; }
        public List<DeveloperViewModel> Developers { get; set; }
        public List<ApplicationDetailsModel> ApplicationDetails { get; set; }
    }
}
