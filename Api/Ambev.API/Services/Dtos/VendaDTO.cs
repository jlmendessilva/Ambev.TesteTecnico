namespace Ambev.API.Services.Dtos
{
    public record VendaDTO(Guid Id,
                           int Numero,
                           DateTime DataCadastro,
                           DateTime DataAtualizacao,
                           Guid ClienteId,
                           decimal ValorTotal,
                           Guid Filial,
                           List<ItemVendaDTO> Itens,
                           bool Cancelado,
                           bool Finalizada);

}
