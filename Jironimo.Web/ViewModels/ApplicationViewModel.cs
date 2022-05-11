namespace Jironimo.Web.ViewModels
{
    public class ApplicationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CategoryName{ get; set; }
    }
}
