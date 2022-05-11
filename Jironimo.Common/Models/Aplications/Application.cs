namespace Jironimo.Common.Models.Aplications
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool PositionRight { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category Category { get; set; }
    }
}

