using Ambev.API.Services.Dtos;
using Ambev.Domain.Entities;
using AutoMapper;

namespace Ambev.API.Services.Mappings
{
    public class MapEntitiesDto : Profile
    {
        public MapEntitiesDto()
        {
            CreateMap<Venda, VendaDTO>().ReverseMap();
            CreateMap<ItemVenda, ItemVendaDTO>().ReverseMap();
        }
    }
}
