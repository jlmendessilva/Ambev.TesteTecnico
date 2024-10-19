using System.Text.Json.Serialization;

namespace Ambev.Domain.Entities
{
    public sealed class Venda : Entity
    {
        [JsonPropertyName("numero")]
        public int Numero { get; private set; }

        [JsonPropertyName("datacadastro")]
        public DateTime DataCadastro { get; private set; }

        [JsonPropertyName("dataatualizacao")]
        public DateTime DataAtualizacao { get; private set; }

        [JsonPropertyName("clienteid")]
        public Guid ClienteId { get; private set; }

        [JsonPropertyName("valortotal")]
        public decimal ValorTotal { get; private set; }

        [JsonPropertyName("filial")]
        public Guid Filial { get; private set; }

        [JsonPropertyName("itens")]
        public List<ItemVenda> Itens { get; private set; }

        [JsonPropertyName("cancelado")]
        public bool Cancelado { get; private set; }

        [JsonPropertyName("finalizada")]
        public bool Finalizada { get; private set; }

        public Venda(Guid clienteId, Guid filial, List<ItemVenda> itensVendas)
        {
            DomainExceptionValidation.When(clienteId == Guid.Empty, "ClientId not valid");
            ClienteId = clienteId;

            DomainExceptionValidation.When(filial == Guid.Empty, "Filial not valid");
            Filial = filial;

            Itens = itensVendas ?? new List<ItemVenda>();
            ValorTotal = Itens.Sum(x => x.ValorTotal);


        }

        public Venda()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            Cancelado = false;
            Finalizada = false;
            Itens = new List<ItemVenda>();
        }

        public Venda(Guid id)
        {
            Id = id;
        }

        public void setDataAtualizacao() => DataAtualizacao = DateTime.Now;
        public void setCliendId(Guid clienteId) => ClienteId = clienteId;
        public void setValorTotal() => CalcularValorTotal();
        public void setFilial(Guid filial) => Filial = filial;
        public void setCanelado(bool canelado = false) => Cancelado = canelado;
        public void setFinalizada(bool finalizada = false) => Finalizada = finalizada;

        public void AtualizaItens(IEnumerable<ItemVenda> itens)
        {
            if (ItensExistem(itens))
                ProcessarItens(itens);
        }

        private bool ItensExistem(IEnumerable<ItemVenda> itens)
        {
            return itens != null && itens.Any();
        }

        private void ProcessarItens(IEnumerable<ItemVenda> itens)
        {
            foreach (var itemVenda in itens)
                AtualizaItem(itemVenda);
        }

        private void AtualizaItem(ItemVenda itemVenda)
        {
            var itensExistentes = EncontrarItensExistentes(itemVenda.Id);

            if (ItensExistem(itensExistentes))
                AtualizarOuAdicionarItem(itensExistentes, itemVenda);
            else
                Itens.Add(itemVenda);

            CalcularValorTotal();
        }


        private IEnumerable<ItemVenda> EncontrarItensExistentes(Guid itemId)
        {
            return Itens.Where(x => x.Id == itemId);
        }

        private void AtualizarOuAdicionarItem(IEnumerable<ItemVenda> itensExistentes, ItemVenda itemVenda)
        {
            var itemExistente = EncontrarItemExistente(itensExistentes, itemVenda);

            if (itemExistente == null)
            {
                AdicionarNovoItem(itemVenda);
                return;
            }

            if (ItensSaoIguais(itemExistente, itemVenda))
            {
                return;
            }

            if (QuantidadeMudou(itemExistente, itemVenda))
            {
                AtualizarQuantidade(itemExistente, itemVenda);
            }
            else if (ValorUnitarioMudou(itemExistente, itemVenda))
            {
                var outroItemComMesmoProdutoEValor = EncontrarItemComMesmoProdutoEValor(itensExistentes, itemVenda);

                if (outroItemComMesmoProdutoEValor != null)
                {
                    outroItemComMesmoProdutoEValor.setQuantidade(outroItemComMesmoProdutoEValor.Quantidade + itemVenda.Quantidade);
                }
                else
                {
                    AdicionarNovoItem(itemVenda);
                }
            }
            else
            {
                AtualizarItem(itemExistente, itemVenda);
            }

            CalcularValorTotal();
        }

        private ItemVenda EncontrarItemExistente(IEnumerable<ItemVenda> itensExistentes, ItemVenda itemVenda)
        {
            return itensExistentes.FirstOrDefault(x => x.Id == itemVenda.Id);
        }

        private ItemVenda EncontrarItemComMesmoProdutoEValor(IEnumerable<ItemVenda> itensExistentes, ItemVenda itemVenda)
        {
            return itensExistentes.FirstOrDefault(x => x.ProdutoId == itemVenda.ProdutoId && x.ValorUnitario == itemVenda.ValorUnitario && x.Id != itemVenda.Id);
        }

        private void AdicionarNovoItem(ItemVenda itemVenda)
        {
            Itens.Add(new ItemVenda(
                itemVenda.VendaId,
                itemVenda.ProdutoId,
                itemVenda.Quantidade,
                itemVenda.ValorUnitario,
                itemVenda.Desconto));
            CalcularValorTotal();
        }

        private bool ItensSaoIguais(ItemVenda itemExistente, ItemVenda itemVenda)
        {
            return itemExistente.Quantidade == itemVenda.Quantidade &&
                   itemExistente.ValorUnitario == itemVenda.ValorUnitario &&
                   itemExistente.ProdutoId == itemVenda.ProdutoId &&
                   itemExistente.Desconto == itemVenda.Desconto;
        }

        private bool QuantidadeMudou(ItemVenda itemExistente, ItemVenda itemVenda)
        {
            return itemExistente.Quantidade != itemVenda.Quantidade;
        }

        private bool ValorUnitarioMudou(ItemVenda itemExistente, ItemVenda itemVenda)
        {
            return itemExistente.ValorUnitario != itemVenda.ValorUnitario;
        }

        private void AtualizarQuantidade(ItemVenda itemExistente, ItemVenda itemVenda)
        {
           itemExistente.setQuantidade(itemVenda.Quantidade);
        }

        private void AtualizarItem(ItemVenda itemExistente, ItemVenda itemVenda)
        {
            itemExistente.setProdutoId(itemVenda.ProdutoId);
            itemExistente.setDesconto(itemVenda.Desconto);
            itemExistente.setValorUnitario(itemVenda.ValorUnitario);
            CalcularValorTotal();
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(item => item.ValorUnitario * item.Quantidade - item.Desconto);
        }


    }
}
