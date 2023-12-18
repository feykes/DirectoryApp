﻿using DirectoryApp.Application.Repositories;
using DirectoryApp.Domain.Entity;
using DirectoryApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Persistence.Repositories
{
    public class ContactInfoReadRepository : ReadRepository<ContactInfo>, IContactInfoReadRepository
    {
        public ContactInfoReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
