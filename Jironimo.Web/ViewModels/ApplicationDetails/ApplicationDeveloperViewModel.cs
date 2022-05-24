using Jironimo.Common.Models.Developers;

namespace Jironimo.Web.ViewModels.ApplicationDetails
{
    public class ApplicationDeveloperViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public bool Outsource { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Developer> Developers { get; set; }
    }
}
