using Ambev.Domain;

namespace Ambev.Data.Interfaces
{
    public interface IVendaRepository
    {
        void Adicionar(Venda venda);
        Venda ObterPorId(Guid id);
        void Atualizar(Venda venda);
        void Remover(Guid id);

    }
}
