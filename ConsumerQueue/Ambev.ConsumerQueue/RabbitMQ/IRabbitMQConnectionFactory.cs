using RabbitMQ.Client;

namespace Ambev.ConsumerQueue.RabbitMQ
{
    public interface IRabbitMQConnectionFactory
    {
        IConnection GetConnection();
    }
}
