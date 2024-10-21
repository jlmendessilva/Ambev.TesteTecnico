
namespace Ambev.EventoMenssage.Eventos
{
    public class ItemCancelado
    {
        public Guid CompraId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime DataCancelamento { get; set; }
    }
}
