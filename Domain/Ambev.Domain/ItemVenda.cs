namespace Ambev.Domain
{
    public sealed class ItemVenda
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal => (ValorUnitario * Quantidade) - Desconto;

        public ItemVenda(Guid produtoId, int quantidade, decimal valorUnitario, decimal desconto)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Desconto = desconto;
        }

    }
}
