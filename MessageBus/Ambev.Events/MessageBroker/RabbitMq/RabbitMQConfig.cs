using RabbitMQ.Client;

namespace Ambev.EventoMenssage.MessageBroker.RabbitMq
{
    public class RabbitMQConfig
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public static class RabbitMQConnectionFactory
    {
        public static IConnection GetConnection(RabbitMQConfig config)
        {
            var factory = new ConnectionFactory()
            {
                HostName = config.HostName,
                UserName = config.UserName,
                Password = config.Password
            };

            return factory.CreateConnection();
        }
    }

}
