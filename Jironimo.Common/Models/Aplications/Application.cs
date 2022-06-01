using Jironimo.Common.Models.Developers;
using Jironimo.Common.Models.ApplicationDeveloper;
namespace Jironimo.Common.Models.Aplications
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
        public string GooglePlayLink { get; set; }
        public string AppStoreLink { get; set; }
        public bool OutSource { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ApplicationDetails> ApplicationDetails {get;set;}
    }
}

