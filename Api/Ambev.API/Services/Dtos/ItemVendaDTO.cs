namespace Ambev.API.Services.Dtos
{
    public record ItemVendaDTO(Guid Id, 
                               Guid VendaId,
                               Guid ProdutoId,
                               decimal Quantidade,
                               decimal ValorUnitario,
                               decimal Desconto,
                               decimal ValorTotal);

}
