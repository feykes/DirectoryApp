using DirectoryApp.Application.Features.Commands.Report.ReportCreate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace DirectoryApp.Infrastructure.RabbitMQ
{
    public class MethodConsumer : IDisposable
    {
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public MethodConsumer(IServiceProvider serviceProvider)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "method_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            _serviceProvider = serviceProvider;
        }

        public void StartConsuming()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var body = ea.Body.ToArray();
                    var stringLocation = Encoding.UTF8.GetString(body);
                    var request = JsonConvert.DeserializeObject<ReportCreateCommandRequest>(stringLocation);

                    await mediator.Send(request);

                    _channel.BasicAck(ea.DeliveryTag, false);
                }

            };

            _channel.BasicConsume(queue: "method_queue", autoAck: false, consumer: consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
