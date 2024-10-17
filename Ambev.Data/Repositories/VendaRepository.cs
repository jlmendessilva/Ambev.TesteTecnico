
using Ambev.Data.Interfaces;
using Ambev.Domain;

namespace Ambev.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly List<Venda> _vendas = new List<Venda>();

        public void Adicionar(Venda venda)
        {
            _vendas.Add(venda);
        }

        public Venda ObterPorId(Guid id)
        {
            return _vendas.FirstOrDefault(v => v.Id == id);
        }

        public void Atualizar(Venda venda)
        {
            var vendaExistente = ObterPorId(venda.Id);
            if (vendaExistente != null)
            {
                vendaExistente = venda;
            }
        }

        public void Remover(Guid id)
        {
            var venda = ObterPorId(id);
            if (venda != null)
            {
                _vendas.Remove(venda);
            }
        }
    }
}
