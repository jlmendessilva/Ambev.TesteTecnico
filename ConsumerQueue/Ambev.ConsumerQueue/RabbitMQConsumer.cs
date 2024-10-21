using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Ambev.ConsumerQueue
{

    public class RabbitMQConfig
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RabbitMQConsumer
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQConsumer(string connectionString)
        {
            var config = ParseConnectionString(connectionString);
            _hostname = config.HostName;
            _username = config.UserName;
            _password = config.Password;
            CreateConnection();
        }

        private RabbitMQConfig ParseConnectionString(string connectionString)
        {
            var config = new RabbitMQConfig();
            var parameters = connectionString.Split(';');
            foreach (var parameter in parameters)
            {
                var keyValue = parameter.Split('=');
                if (keyValue.Length == 2)
                {
                    var key = keyValue[0].Trim().ToLower();
                    var value = keyValue[1].Trim();

                    switch (key)
                    {
                        case "hostname":
                            config.HostName = value;
                            break;
                        case "username":
                            config.UserName = value;
                            break;
                        case "password":
                            config.Password = value;
                            break;
                    }
                }
            }
            return config;
        }

        private void CreateConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
        }

        public void Consume(string queueName)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[x] {DateTime.Now} - Queue: {queueName} Received: {message}");
                };

                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
