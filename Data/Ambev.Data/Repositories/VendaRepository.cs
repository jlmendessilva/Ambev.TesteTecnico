
using Ambev.Data.Context;
using Ambev.Data.Interfaces;
using Ambev.Domain;

namespace Ambev.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private ApplicationDbContext _context;

        public VendaRepository(ApplicationDbContext context)
        {
                _context = context;
        }

        public void Adicionar(Venda venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();
        }

        public Venda ObterPorId(Guid id)
        {
            return _context.Venda.FirstOrDefault(v => v.Id == id);
        }

        public void Atualizar(Venda venda)
        {
            var vendaExistente = ObterPorId(venda.Id);

            if (vendaExistente != null)
            {
                vendaExistente.setDataUpdated();
                vendaExistente.setCliendId(venda.ClienteId);
                vendaExistente.setFilial(venda.Filial);
                vendaExistente.AtualizaItens(venda.Itens);
                vendaExistente.setValorTotal();

                _context.Venda.Add(vendaExistente);
                _context.SaveChanges();
            }
        }

        public void Remover(Guid id)
        {
            var venda = ObterPorId(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }
        }
    }
}
