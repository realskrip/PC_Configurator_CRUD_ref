using Microsoft.EntityFrameworkCore;

namespace PC_configurator.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SystemUnit> SystemUnits { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
