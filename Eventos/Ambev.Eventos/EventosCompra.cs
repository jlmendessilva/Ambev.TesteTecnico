namespace Ambev.Eventos
{
    public class CompraAlterada
    {
        public Guid CompraId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid ClienteId { get; set; }
    }
    public class CompraCancelada
    {
        public Guid CompraId { get; set; }
        public DateTime DataCancelamento { get; set; }
    }
    public class CompraCriada
    {
        public Guid CompraId { get; set; }
        public DateTime DataCompra { get; set; }
        public Guid ClienteId { get; set; }
    }
    public class ItemCancelado
    {
        public Guid CompraId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime DataCancelamento { get; set; }
    }
}
