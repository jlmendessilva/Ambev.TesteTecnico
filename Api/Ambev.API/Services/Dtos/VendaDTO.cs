namespace Ambev.API.Services.Dtos
{
   /* public record VendaDTO(Guid Id,
                           int Numero,
                           DateTime DataCadastro,
                           DateTime DataAtualizacao,
                           Guid ClienteId,
                           decimal ValorTotal,
                           Guid Filial,
                           List<ItemVendaDTO> Itens,
                           bool Cancelado,
                           bool Finalizada);*/

    public record VendaDTO()
    {
        public Guid Id {  get; init; }
        public int Numero { get; init; }
        public DateTime DataCadastro { get; init; }
        public DateTime DataAtualizacao { get; init; }
        public Guid ClienteId { get; init; }
        public decimal ValorTotal { get; init; }
        public Guid Filial { get; init; }
        public List<ItemVendaDTO> Itens { get; init; } = new List<ItemVendaDTO>();
        public bool Cancelado { get; init; }
        public bool Finalizada { get; init; }
    }

}
