namespace Jironimo.Web.ViewModels.ApplicationDetails
{
    public class ApplicationDetailsViewModel
    {
        public ApplicationDeveloperViewModel Application { get; set; }
        public List<ApplicationViewModel> Applications { get; set; }
        public List<ApplicationDetailsModel> ApplicationDetails { get; set; }
    }
}
