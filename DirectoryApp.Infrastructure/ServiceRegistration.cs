using DirectoryApp.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<RabbitMQService>();
            services.AddSingleton<MethodConsumer>();
        }
    }
}
