
namespace Ambev.MessageBus.Eventos
{
    public class CompraCriada
    {
        public Guid CompraId { get; set; }
        public DateTime DataCompra { get; set; }
        public Guid ClienteId { get; set; }
    }
}
