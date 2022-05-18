namespace Jironimo.Web.Areas.Admin.Models
{
    public class ApplicationCreateViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public bool OutSource { get; set; }
        public Guid CategoryId { get; set; }
    }
}
