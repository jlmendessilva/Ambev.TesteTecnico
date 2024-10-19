using Ambev.API.Services.Dtos;


namespace Ambev.API.Services.Interfaces
{
    public interface IVendaService
    {
        Task<VendaDTO> Adicionar(VendaDTO vendaDto);
        Task<VendaDTO> BuscarPorId(Guid id);
        Task<VendaDTO> BuscarPorNumero(int number);
        Task<IEnumerable<VendaDTO>> BuscarTodos();
        Task<VendaDTO> Atualizar(Guid id, VendaDTO vendaDto);
        Task<VendaDTO> AdicionarItem(Guid id, IEnumerable<ItemVendaDTO> itens);
        Task Delete(Guid id);
    }
}
