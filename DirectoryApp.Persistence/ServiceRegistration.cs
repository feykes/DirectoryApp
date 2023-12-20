using DirectoryApp.Application.Repositories;
using DirectoryApp.Persistence.Contexts;
using DirectoryApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<IContactInfoReadRepository, ContactInfoReadRepository>();
            services.AddScoped<IContactInfoWriteRepository, ContactInfoWriteRepository>();
            services.AddScoped<IReportReadRepository, ReportReadRepository>();
            services.AddScoped<IReportWriteRepository, ReportWriteRepository>();
        }
    }
}
