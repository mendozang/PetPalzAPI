using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly VeterinarioService _veterinarioService;

        public VeterinarioController(VeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        [HttpPost]
        public IActionResult CrearVeterinario([FromBody] VeterinarioCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var veterinario = _veterinarioService.CrearVeterinario(dto);
            return CreatedAtAction(nameof(GetVeterinario), new { id = veterinario.Id }, veterinario);
        }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetVeterinario(int id)
    {
        var veterinario = await _veterinarioService.GetVeterinarioByIdAsync(id);

        if (veterinario == null)
            return NotFound();

        return Ok(veterinario);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVeterinarios()
    {
        var veterinarios = await _veterinarioService.GetAllVeterinariosAsync();
        return Ok(veterinarios);
    }

        [HttpPut("{id}")]
        public IActionResult ActualizarVeterinario(int id, [FromBody] VeterinarioUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _veterinarioService.ActualizarVeterinario(id, dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVeterinario(int id)
        {
            var eliminado = _veterinarioService.EliminarVeterinario(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
