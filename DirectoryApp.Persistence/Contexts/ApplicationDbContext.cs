using DirectoryApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DirectoryApp.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasMany(x => x.ContactInfos).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
