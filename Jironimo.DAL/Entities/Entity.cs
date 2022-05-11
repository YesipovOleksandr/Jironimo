using System.ComponentModel.DataAnnotations;

namespace Jironimo.DAL.Entities
{
    public abstract class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
