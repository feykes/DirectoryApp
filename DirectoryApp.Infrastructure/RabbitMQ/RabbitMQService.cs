using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace DirectoryApp.Infrastructure.RabbitMQ
{
    public class RabbitMQService : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue:"method_queue",durable:true, exclusive: false, autoDelete: false, arguments: null);
        }

        public void PublishToQueue(string request)
        {
            var body=Encoding.UTF8.GetBytes(request);

            _channel.BasicPublish(exchange: "", routingKey: "method_queue", basicProperties: null, body: body);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
