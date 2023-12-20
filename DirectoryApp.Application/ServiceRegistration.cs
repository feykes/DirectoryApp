using AutoMapper;
using DirectoryApp.Application.Mappings.ContactInfoMap;
using DirectoryApp.Application.Mappings.PersonDetailMap;
using DirectoryApp.Application.Mappings.PersonMap;
using DirectoryApp.Application.Mappings.ReportDetailMap;
using DirectoryApp.Application.Mappings.ReportMap;
using DirectoryApp.Infrastructure.RabbitMQ;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new PersonProfile(),
                    new ContactInfoProfile(),
                    new PersonDetailProfile(),
                    new ReportProfile(),
                    new ReportDetailProfile()
                });
            });
            services.AddScoped<MethodConsumer>();
        }
    }
}
