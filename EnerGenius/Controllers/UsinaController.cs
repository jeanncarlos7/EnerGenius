using Microsoft.AspNetCore.Mvc;
using EnerGenius.Models;
using EnerGenius.HttpObjects.Usina;
using EnerGenius.Services.Interfaces;

namespace EnerGenius.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsinaController : ControllerBase
    {
        private readonly IUsinaService _service;

        public UsinaController(IUsinaService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUsina(UsinaInsertRequest usinaInsertRequest)
        {
            try
            {
                var id = await _service.CreateAsync(usinaInsertRequest);
                return CreatedAtAction(nameof(GetUsina), new { id }, null);
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usina), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsina(string id)
        {
            var usina = await _service.GetByIdAsync(id);
            if (usina == null) return NotFound();
            return Ok(usina);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUsina(UsinaUpdateRequest usinaUpdateRequest)
        {
            try
            {
                await _service.UpdateAsync(usinaUpdateRequest);
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
        public async Task<IActionResult> DeleteUsina(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
