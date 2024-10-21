
namespace Ambev.EventoMenssage.Publicacao.Services
{
    public interface IEventoPublicacao
    {
        void Publica<T>(string queueName, T evento);
    }
}
