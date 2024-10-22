using RabbitMQ.Client;


namespace Ambev.Eventos.Broker
{
    public interface IRabbitMQConnectionFactory
    {
        IConnection GetConnection();
    }

}
