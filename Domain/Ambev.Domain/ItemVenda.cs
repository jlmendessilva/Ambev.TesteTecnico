namespace Ambev.Domain
{
    public sealed class ItemVenda
    {
        public Guid Id { get; private set; }
        public Guid VendaId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal => (ValorUnitario * Quantidade) - Desconto;
        public Venda Venda { get; private set; }

        public ItemVenda(Guid vendaId, Guid produtoId, int quantidade, decimal valorUnitario, decimal desconto)
        {
            Id = Guid.NewGuid();
            VendaId = vendaId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Desconto = desconto;
        }

        public void setProdutoId(Guid produtoId) => this.ProdutoId = produtoId;
        public void setQuantidade(decimal quantidade) => this.Quantidade = quantidade;

    }
}
