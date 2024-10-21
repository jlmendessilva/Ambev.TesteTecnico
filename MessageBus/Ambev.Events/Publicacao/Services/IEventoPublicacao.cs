
namespace Ambev.MessageBus.Publicacao.Services
{
    public interface IEventoPublicacao
    {
        void Publica<T>(string queueName, T evento);
    }
}
