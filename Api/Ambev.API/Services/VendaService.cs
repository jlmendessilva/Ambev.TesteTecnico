using Ambev.API.Services.Dtos;
using Ambev.API.Services.Interfaces;
using Ambev.Data.Interfaces;
using Ambev.Domain.Entities;
using AutoMapper;

namespace Ambev.API.Services
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _vendarepositorio;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendarepositorio, IMapper mapper)
        {
            _vendarepositorio = vendarepositorio ?? throw new ArgumentNullException(nameof(_vendarepositorio));
            _mapper = mapper;
        }

        public async Task<VendaDTO> Adicionar(VendaDTO vendaDto)
        {
            var vendaEntities = _mapper.Map<Venda>(vendaDto);

            var venda = await _vendarepositorio.CreateAsync(vendaEntities);

            return _mapper.Map<VendaDTO>(venda);
        }

        public async Task<VendaDTO> BuscarPorId(Guid id)
        {
            var vendaEntities = await _vendarepositorio.GetByIdAsync(id);

            return _mapper.Map<VendaDTO>(vendaEntities);
        }

        public async Task<IEnumerable<VendaDTO>> BuscarTodos()
        {
            var vendaEntities = await _vendarepositorio.GetAllAsync();

            return _mapper.Map<IEnumerable<VendaDTO>>(vendaEntities);
        }

        public async Task<VendaDTO> Atualizar(Guid id, VendaDTO vendaDto)
        {
            var vendaEntities  = _mapper.Map<Venda>(vendaDto);

           await _vendarepositorio.UpdateAsync(id, vendaEntities);

            return vendaDto;
        }

        public async Task Delete(Guid id)
        {
            await _vendarepositorio.DeleteAsync(id);

        }

        public async Task<VendaDTO> AdicionarItem(Guid id, IEnumerable<ItemVendaDTO> itensDto)
        {
            var itensVendaEntities = _mapper.Map<IEnumerable<ItemVenda>>(itensDto);

            var vendaEntities = await _vendarepositorio.AddItemAsync(id, itensVendaEntities);

            return _mapper.Map<VendaDTO>(vendaEntities);
        }

        public async Task<VendaDTO> BuscarPorNumero(int number)
        {
            var vendaEntities = await _vendarepositorio.GetByNumberAsync(number);

            return _mapper.Map<VendaDTO>(vendaEntities);
        }
    }
}
