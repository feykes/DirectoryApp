using DirectoryApp.Application.Repositories;
using DirectoryApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync()
        {
            var data = await Table.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
    }
}
