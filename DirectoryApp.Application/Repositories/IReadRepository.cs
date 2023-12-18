using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}
