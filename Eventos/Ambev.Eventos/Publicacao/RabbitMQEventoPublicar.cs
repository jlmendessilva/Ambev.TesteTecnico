using Ambev.Eventos.Broker;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Ambev.Eventos.Publicacao
{
    public class RabbitMQEventoPublicar : IEventoPublicacao
    {
        private readonly IRabbitMQConnectionFactory _rabbitMQConnectionFactory;

        public RabbitMQEventoPublicar(IRabbitMQConnectionFactory rabbitMQConnectionFactory)
        {
            _rabbitMQConnectionFactory = rabbitMQConnectionFactory;
        }

        public void Publica<T>(string queueName, T evento)
        {
            using (var connection = _rabbitMQConnectionFactory.GetConnection())
            using (var channel = connection.CreateModel())
            {
                ConfigurarFila(channel, queueName);
                var messageBody = SerializarEvento(evento);
                PublicarMensagem(channel, queueName, messageBody);
            }
        }

        private void ConfigurarFila(IModel channel, string queueName)
        {
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        private byte[] SerializarEvento<T>(T evento)
        {
            var message = JsonSerializer.Serialize(evento);
            return Encoding.UTF8.GetBytes(message);
        }

        private void PublicarMensagem(IModel channel, string queueName, byte[] body)
        {
            channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }

}
