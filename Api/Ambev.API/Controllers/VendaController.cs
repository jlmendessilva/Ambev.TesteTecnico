using Ambev.API.Services.Dtos;
using Ambev.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ambev.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _venda;

        public VendaController(IVendaService venda)
        {
            _venda = venda;
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

            return Ok(venda);
        }


        [HttpPut("Update/{id}")]
        public async Task<ActionResult<VendaDTO>> Update(Guid id, VendaDTO vendaDto)
        {
            return await _venda.Atualizar(id, vendaDto);
            
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _venda.Delete(id);
            return NoContent();
        }

        [HttpPost("addItens/{id}")]
        public async Task<ActionResult> AdicionarItens(Guid id, IEnumerable<ItemVendaDTO> itens)
        {
            var addItens = await _venda.AdicionarItem(id, itens);
            return CreatedAtAction(nameof(AdicionarItens), new { id }, addItens);
        }
    }
}
