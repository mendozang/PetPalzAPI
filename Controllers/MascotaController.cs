using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly MascotaService _mascotaService;

        public MascotaController(MascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        public IActionResult CrearMascota([FromBody] MascotaCreateDTO mascotaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mascota = _mascotaService.CrearMascota(mascotaDto);
            return CreatedAtAction(nameof(GetMascota), new { id = mascota.Id }, mascota);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMascotas()
        {
            var mascotasDto = await _mascotaService.GetAllMascotasAsync();
            return Ok(mascotasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMascota(int id)
        {
            var mascotaDto = await _mascotaService.GetMascotaByIdAsync(id);

            if (mascotaDto == null)
                return NotFound();

            return Ok(mascotaDto);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarMascota(int id, [FromBody] MascotaUpdateDTO mascotaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _mascotaService.ActualizarMascota(id, mascotaDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMascota(int id)
        {
            var eliminado = _mascotaService.EliminarMascota(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
