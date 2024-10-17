namespace Ambev.Domain
{
    public sealed class Venda
    {
        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public string Filial { get; private set; }
        public List<ItemVenda> Itens { get; private set; }
        public bool Cancelado { get; private set; }

        public Venda(Guid clienteId, string filial)
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
            ClienteId = clienteId;
            Filial = filial;
            Itens = new List<ItemVenda>();
            Cancelado = false;
        }

        public void AdicionarItem(ItemVenda item)
        {
            Itens.Add(item);
            CalcularValorTotal();
        }

        public void Cancelar()
        {
            Cancelado = true;
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(i => i.ValorTotal);
        }
    }
}
