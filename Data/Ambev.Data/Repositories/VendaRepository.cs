
using Ambev.Data.Context;
using Ambev.Data.Interfaces;
using Ambev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private ApplicationDbContext _context;

        public VendaRepository(ApplicationDbContext context)
        {
                _context = context;
        }

        public async Task<Venda> CreateAsync(Venda venda)
        {
             _context.Venda.Add(venda);
             await _context.SaveChangesAsync();

            return venda;
        }

        public async Task<Venda> GetByNumberAsync(int numero)
        {
            return await _context.Venda.FirstOrDefaultAsync(x => x.Numero == numero);
        }

        public async Task<Venda> GetByIdAsync(Guid id)
        {
            return await _context.Venda.Include(x => x.Itens).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Venda> UpdateAsync(Guid id, Venda venda)
        {
            var vendaExistente = await GetByIdAsync(id);

            if (vendaExistente == null)
                throw new Exception("Venda não encontrada.");

            vendaExistente.setDataAtualizacao();
            vendaExistente.setCliendId(venda.ClienteId);
            vendaExistente.setFilial(venda.Filial);

            if(venda.Itens.Count > 0)
                vendaExistente.AtualizaItens(venda.Itens);

            vendaExistente.setValorTotal();

            _context.Venda.Update(vendaExistente);
            await _context.SaveChangesAsync();


            return vendaExistente;
        }

        public async Task DeleteAsync(Guid id)
        {
            var venda = await GetByIdAsync(id);

            if (venda == null)
                throw new Exception("Venda não encontrada.");

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Venda>> GetAllAsync()
        {
            return await _context.Venda.Include(x => x.Itens).ToListAsync();
        }

        public async Task<Venda> AddItemAsync(Guid id, IEnumerable<ItemVenda> itens)
        {
            var venda = await GetByIdAsync(id);

            if (venda == null)
                throw new Exception("Venda não encontrada.");

            venda.Itens.AddRange(itens);
            return await UpdateAsync(id, venda);


        }

    }
}
