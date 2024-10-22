using Ambev.ConsumerQueue.RabbitMQ;
using RabbitMQ.Client;

namespace Ambev.ConsumerQueue
{
    public class RabbitMQConnectionFactory : IRabbitMQConnectionFactory
    {
        private readonly RabbitMQConfig _config;

        public RabbitMQConnectionFactory(RabbitMQConfig config)
        {
            _config = config;
        }

        public IConnection GetConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _config.HostName,
                UserName = _config.UserName,
                Password = _config.Password,
                VirtualHost = _config.VirtualHost,
                Port = _config.Port,
                Ssl = new SslOption
                {
                    Enabled = true,
                    ServerName = _config.HostName
                }
            };

            return factory.CreateConnection();
        }
    }
}


