namespace Jironimo.Web.ViewModels
{
    public class ApplicationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
        public string GooglePlayLink { get; set; }
        public string AppStoreLink { get; set; }
        public bool Outsource { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CategoryName{ get; set; }
    }
}
