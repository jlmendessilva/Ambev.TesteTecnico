using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Ambev.ConsumerQueue.RabbitMQ
{
    public class RabbitMQConsumer
    {
        private readonly IRabbitMQConnectionFactory _rabbitMQConnectionFactory;
        private IConnection _connection;

        public RabbitMQConsumer(IRabbitMQConnectionFactory rabbitMQConnectionFactory)
        {
            _rabbitMQConnectionFactory = rabbitMQConnectionFactory;
            _connection = _rabbitMQConnectionFactory.GetConnection();
        }

        public void Consume(IEnumerable<string> queueNames)
        {
            using (var channel = _connection.CreateModel())
            {
                foreach (var queueName in queueNames)
                {
                    ConfigurarFila(channel, queueName);
                    var consumer = CriarConsumer(channel, queueName);
                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
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

        private EventingBasicConsumer CriarConsumer(IModel channel, string queueName)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[x] {DateTime.Now} - Queue: {queueName} Received: {message}");
            };
            return consumer;
        }
    }
}
