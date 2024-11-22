using Microsoft.AspNetCore.Mvc;
using EnerGenius.HttpObjects.Usuario;
using EnerGenius.Services.Interfaces;

namespace EnerGenius.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUsuario(UsuarioInsertRequest usuarioInsertRequest)
        {
            var id = await _service.CreateAsync(usuarioInsertRequest);

            return CreatedAtAction(nameof(GetUsuario), new { id }, null);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuario(string id)
        {
            var usuario = await _service.GetByIdAsync(id);

            if (usuario == null) return NotFound();

            var usuarioResponse = new UsuarioResponse
            {
                Id = id,
                Nome = usuario.Nome,
                Ativo = usuario.Ativo,
                DataCadastro = usuario.DataCadastro,
                Email = usuario.Email
            };

            return Ok(usuarioResponse);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _service.GetAsync();

            if (usuarios == null) return NotFound();


            return Ok(usuarios);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUsuario(UsuarioUpdateRequest usuarioUpdateRequest)
        {
            await _service.UpdateAsync(usuarioUpdateRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
