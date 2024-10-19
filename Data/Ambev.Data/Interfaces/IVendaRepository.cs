using Ambev.Domain.Entities;

namespace Ambev.Data.Interfaces
{
    public interface IVendaRepository 
    { 
        Task<IEnumerable<Venda>> GetAllAsync();
        Task<Venda> CreateAsync(Venda venda);
        Task<Venda> GetByNumberAsync(int number);
        Task<Venda> GetByIdAsync(Guid id);
        Task<Venda> UpdateAsync(Guid id, Venda venda);
        Task DeleteAsync(Guid id);
        Task<Venda> AddItemAsync(Guid id, IEnumerable<ItemVenda> itens);

    }
}
