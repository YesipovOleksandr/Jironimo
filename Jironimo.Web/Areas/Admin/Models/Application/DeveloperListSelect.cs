namespace Jironimo.Web.Areas.Admin.Models.Application
{
    public class DeveloperListSelect
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Position { get; set; }
        public bool Selected { get; set; } = false;
    }
}
