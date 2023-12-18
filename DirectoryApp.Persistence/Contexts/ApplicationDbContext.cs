using DirectoryApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DirectoryApp.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
