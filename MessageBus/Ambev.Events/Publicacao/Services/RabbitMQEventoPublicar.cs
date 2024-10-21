using RabbitMQ.Client;
using System.Text;
using System.Text.Json;


namespace Ambev.MessageBus.Publicacao.Services
{
    public class RabbitMQEventoPublicar : IEventoPublicacao
    {
        private readonly IConnection _connection;

        public RabbitMQEventoPublicar(IConnection connection)
        {
            _connection = connection;
        }
        public void Publica<T>(string queueName, T evento)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonSerializer.Serialize(evento);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
