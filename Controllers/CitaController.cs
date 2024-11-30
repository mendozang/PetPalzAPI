using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaService _citaService;

        public CitaController(CitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpPost]
        public IActionResult CrearCita([FromBody] CitaCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cita = _citaService.CrearCita(dto);
            return CreatedAtAction(nameof(ObtenerCitaPorId), new { id = cita.Id }, cita);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCitaPorId(int id)
        {
            var citaDto = await _citaService.GetCitaByIdAsync(id);

            if (citaDto == null)
                return NotFound();

            return Ok(citaDto);
        }

        [HttpGet]
        public IActionResult ObtenerTodasLasCitas()
        {
            var citas = _citaService.ObtenerTodasLasCitas();
            return Ok(citas);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarCita(int id, [FromBody] CitaUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _citaService.ActualizarCita(id, dto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCita(int id)
        {
            var eliminado = _citaService.EliminarCita(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
