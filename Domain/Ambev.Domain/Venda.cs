namespace Ambev.Domain
{
    public sealed class Venda
    {
        public Guid Id { get; private set; }
        public DateTime DataCreated { get; private set; }
        public DateTime DataUpdated { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public Guid Filial { get; private set; }
        public List<ItemVenda> Itens { get; private set; }
        public bool Cancelado { get; private set; }
        public bool Finalizada { get; private set; }

        public Venda(Guid clienteId, Guid filial)
        {
            Id = Guid.NewGuid();
            DataCreated = DateTime.Now;
            ClienteId = clienteId;
            Filial = filial;
            Itens = new List<ItemVenda>();
            Cancelado = false;
        }

        public void setDataUpdated() => DataUpdated = DateTime.Now;
        public void setCliendId(Guid clienteId) => ClienteId = clienteId; 
        public void setValorTotal() => CalcularValorTotal();
        public void setFilial(Guid filial) =>  Filial = filial; 
        public void setCanelado(bool canelado = true) => Cancelado = canelado;
        public void setFinalizada(bool finalizada = false) => Finalizada = finalizada;

        public void AdicionarNovoItem(ItemVenda item)
        {
            Itens.Add(item);
            CalcularValorTotal();
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.ValorTotal);
        }

        public void AtualizaItens(IEnumerable<ItemVenda> itens)
        {
            if (ItensExistem(itens))
            {
                ProcessarItens(itens);
            }
        }

        private bool ItensExistem(IEnumerable<ItemVenda> itens)
        {
            return itens != null && itens.Any();
        }

        private void ProcessarItens(IEnumerable<ItemVenda> itens)
        {
            foreach (var itemVenda in itens)
            {
                AtualizaItem(itemVenda);
            }
        }

        private void AtualizaItem(ItemVenda itemVenda)
        {
            var itensExistentes = EncontrarItensExistentes(itemVenda.Id);
            if (ItensExistem(itensExistentes))
            {
                AtualizarItens(itensExistentes, itemVenda);
            }
            else
            {
                AdicionarNovoItem(itemVenda);
            }
            CalcularValorTotal();
        }

        private IEnumerable<ItemVenda> EncontrarItensExistentes(Guid itemId)
        {
            return Itens.Where(x => x.Id == itemId);
        }

        private void AtualizarItens(IEnumerable<ItemVenda> itens, ItemVenda itemVenda)
        {
            foreach (var item in itens)
            {
                AtualizarItem(item, itemVenda);
            }
        }

        private void AtualizarItem(ItemVenda item, ItemVenda itemVenda)
        {
            item.setQuantidade(itemVenda.Quantidade);
            item.setProdutoId(itemVenda.ProdutoId);
        }

    }
}
