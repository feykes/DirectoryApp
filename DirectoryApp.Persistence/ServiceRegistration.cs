using DirectoryApp.Application.Repositories;
using DirectoryApp.Persistence.Contexts;
using DirectoryApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Persistence
{
    public static class ServiceRegistration 
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<IContactInfoReadRepository, ContactInfoReadRepository>();
            services.AddScoped<IContactInfoWriteRepository, ContactInfoWriteRepository>();

        }
    }
}
