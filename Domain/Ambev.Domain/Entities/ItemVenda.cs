using System.Text.Json.Serialization;

namespace Ambev.Domain.Entities
{
    public sealed class ItemVenda : Entity
    {
        [JsonPropertyName("vendaid")]
        public Guid VendaId { get; private set; }

        [JsonPropertyName("produtoid")]
        public Guid ProdutoId { get; private set; }

        [JsonPropertyName("quantidade")]
        public decimal Quantidade { get; private set; }

        [JsonPropertyName("valorunitario")]
        public decimal ValorUnitario { get; private set; }

        [JsonPropertyName("desconto")]
        public decimal Desconto { get; private set; }

        [JsonPropertyName("valortotal")]
        public decimal ValorTotal => ValorUnitario * Quantidade - Desconto;

        public Venda? Venda { get; private set; }

        public ItemVenda(Guid vendaId, Guid produtoId, Decimal quatidade, decimal valorUnitario, decimal desconto)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            Quantidade = quatidade;
            ValorUnitario = valorUnitario;
            Desconto = desconto;
        }

        public ItemVenda()
        {
                
        }

        public void setProdutoId(Guid produtoId) => ProdutoId = produtoId;
        public void setQuantidade(decimal quantidade) => Quantidade = quantidade;
        public void setValorUnitario(decimal valorUnitario) => ValorUnitario = valorUnitario;
        public void setDesconto(decimal desconto) => ValorUnitario = desconto;

    }
}
