using Ambev.API.Services.Dtos;
using Ambev.API.Services.Interfaces;
using Ambev.Eventos;
using Ambev.Eventos.Publicacao;
using Microsoft.AspNetCore.Mvc;


namespace Ambev.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _venda;
        private readonly IEventoPublicacao _evento;


        public VendaController(IVendaService venda, IEventoPublicacao evento)
        {
            _venda = venda;
            _evento = evento;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<VendaDTO>> GetAll()
        {
            var venda = await _venda.BuscarTodos();
            if (venda == null) return NotFound();
            return Ok(venda);
        }

        [HttpGet("getNumber/{number}")]
        public async Task<ActionResult<VendaDTO>> GetByNumber(int number)
        {
            var venda = await _venda.BuscarPorNumero(number);
            if (venda == null) return NotFound();
            return Ok(venda);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<VendaDTO>> Create(VendaDTO vendaDto)
        {
            if (vendaDto == null || !ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var venda = await _venda.Adicionar(vendaDto);

            _evento.Publica("compraCriada", new CompraCriada
            {
                CompraId = venda.Id,
                DataCompra = venda.DataCadastro,
                ClienteId = venda.ClienteId

            });

            return Ok(venda);
        }


        [HttpPut("Update/{id}")]
        public async Task<ActionResult<VendaDTO>> Update(Guid id, VendaDTO vendaDto)
        {
            var venda = await _venda.Atualizar(id, vendaDto);

            _evento.Publica("compraAlterada",new CompraAlterada
            {
                CompraId = venda.Id,
                DataAlteracao = venda.DataAtualizacao,
                ClienteId = venda.ClienteId

            });

            return Ok(venda);
            
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _venda.Delete(id);

            _evento.Publica("compraCancelada",new CompraCancelada
            {
                CompraId = id,
                DataCancelamento = DateTime.Now,

            });

            return NoContent();
        }

        [HttpPost("addItens")]
        public async Task<ActionResult> AdicionarItens(Guid id, IEnumerable<ItemVendaDTO> itens)
        {
            var addItens = await _venda.AdicionarItem(id, itens);
            return CreatedAtAction(nameof(AdicionarItens), new { id }, addItens);
        }

        [HttpDelete("deleteItens")]
        public async Task<ActionResult<VendaDTO>> DeleteItem(Guid vendaId, Guid itemId)
        {
            var venda = await _venda.DeleteItem(vendaId, itemId);

            _evento.Publica("ItemCancelado", new ItemCancelado
            {
                CompraId = vendaId,
                ItemId = itemId,
                DataCancelamento = DateTime.Now

            });

            return Ok(venda);

        }
    }
}
