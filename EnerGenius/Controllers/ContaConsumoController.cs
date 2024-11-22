using Microsoft.AspNetCore.Mvc;
using EnerGenius.HttpObjects.ContaConsumo;
using EnerGenius.Services.Interfaces;

namespace EnerGenius.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaConsumoController : ControllerBase
    {
        private readonly IContaConsumoService _contaConsumoService;

        public ContaConsumoController(IContaConsumoService contaConsumoService)
        {
            _contaConsumoService = contaConsumoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContaConsumo(ContaConsumoInsertRequest contaConsumoInsertRequest)
        {
            var id = await _contaConsumoService.CreateContaConsumoAsync(contaConsumoInsertRequest);

            return CreatedAtAction(nameof(GetContaConsumo), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContaConsumo(string id)
        {
            var contaConsumo = await _contaConsumoService.GetContaConsumoByIdAsync(id);
            if (contaConsumo == null) return NotFound();
            return Ok(contaConsumo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContaConsumo(ContaConsumoUpdateRequest contaConsumoUpdateRequest)
        {
            await _contaConsumoService.UpdateContaConsumoAsync(contaConsumoUpdateRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContaConsumo(string id)
        {
            await _contaConsumoService.DeleteContaConsumoAsync(id);
            return NoContent();
        }
    }
}
