using DirectoryApp.Application;
using DirectoryApp.Application.Features.Commands.Report.ReportCreate;
using DirectoryApp.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace DirectoryApp.Infrastructure.RabbitMQ
{
    public class MethodConsumer : IDisposable
    {
        private readonly IModel _channel;
        private readonly IMediator _mediator;

        public MethodConsumer(IMediator mediator)
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
            _mediator = mediator;
        }

        public void StartConsuming()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var stringLocation = Encoding.UTF8.GetString(body);
                var request = JsonConvert.DeserializeObject<ReportCreateCommandRequest>(stringLocation);

                await _mediator.Send(request);

                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: "method_queue", autoAck: false, consumer: consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
