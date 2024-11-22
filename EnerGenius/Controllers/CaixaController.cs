using Microsoft.AspNetCore.Mvc;
using EnerGenius.HttpObjects.Caixa;
using EnerGenius.Services.Interfaces;
using EnerGenius.Models;

namespace EnerGenius.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaService _service;

        public CaixaController( ICaixaService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCaixa(CaixaInsertRequest caixaInsertRequest)
        {
            try
            {
                var id = await _service.CreateCaixaAsync(caixaInsertRequest);
                return CreatedAtAction(nameof(GetCaixa), new { id }, null);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return  StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Caixa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCaixa(string id)
        {
            try
            {
                var caixa = await _service.GetCaixaByIdAsync(id);
                if (caixa == null) return NotFound();
                return Ok(caixa);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCaixa(CaixaUpdateRequest caixaUpdateRequest)
        {
            try
            {
                await _service.UpdateCaixaAsync(caixaUpdateRequest);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCaixa(string id)
        {
            try
            {
                await _service.DeleteCaixaAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
