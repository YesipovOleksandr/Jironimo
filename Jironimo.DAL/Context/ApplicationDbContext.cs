using Microsoft.EntityFrameworkCore;

namespace Jironimo.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<User>().HasIndex(u => u.Phone).IsUnique();
            //builder.Entity<User>().HasIndex(u => u.NormalizeEmail).IsUnique();

            //builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.Role });
            //var enumRoleNameConverter = new EnumToStringConverter<RoleName>();
            //builder.Entity<UserRole>().Property(ud => ud.Role).HasConversion(enumRoleNameConverter);

        }
    }
}

