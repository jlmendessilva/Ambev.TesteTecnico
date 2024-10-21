
namespace Ambev.EventoMenssage.Eventos
{
    public class CompraCancelada
    {
        public Guid CompraId { get; set; }
        public DateTime DataCancelamento { get; set; }
    }
}
