using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] UsuarioCreateDTO usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = _usuarioService.CrearUsuario(usuarioDto);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpGet]
    public async Task<IActionResult> GetAllUsuarios()
    {
        var usuariosDto = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuariosDto);
    }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuario(int id)
    {
        var usuarioDto = await _usuarioService.GetUsuarioByIdAsync(id);

        if (usuarioDto == null)
            return NotFound();

        return Ok(usuarioDto);
    }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] UsuarioUpdateDTO usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _usuarioService.ActualizarUsuario(id, usuarioDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var eliminado = _usuarioService.EliminarUsuario(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
