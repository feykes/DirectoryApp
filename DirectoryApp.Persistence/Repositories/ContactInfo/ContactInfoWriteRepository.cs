using DirectoryApp.Application.Repositories;
using DirectoryApp.Domain.Entity;
using DirectoryApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Persistence.Repositories
{
    public class ContactInfoWriteRepository : WriteRepository<ContactInfo>, IContactInfoWriteRepository
    {
        public ContactInfoWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
