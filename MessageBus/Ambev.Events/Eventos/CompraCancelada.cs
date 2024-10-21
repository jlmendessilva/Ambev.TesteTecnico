
namespace Ambev.MessageBus.Eventos
{
    public class CompraCancelada
    {
        public Guid CompraId { get; set; }
        public DateTime DataCancelamento { get; set; }
    }
}
