namespace Jironimo.DAL.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
