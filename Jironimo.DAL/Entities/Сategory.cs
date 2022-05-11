namespace Jironimo.DAL.Entities
{
    public class Сategory : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
