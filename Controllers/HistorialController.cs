using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialMedicoController : ControllerBase
    {
        private readonly HistorialMedicoService _historialService;

        public HistorialMedicoController(HistorialMedicoService historialService)
        {
            _historialService = historialService;
        }

        [HttpPost]
        public IActionResult CrearHistorial([FromBody] HistorialMedicoCreateDTO historialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var historial = _historialService.CrearHistorial(historialDto);
            return CreatedAtAction(nameof(GetHistorialMedico), new { id = historial.Id }, historial);
        }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetHistorialMedico(int id)
    {
        var historialDto = await _historialService.GetHistorialMedicoByIdAsync(id);

        if (historialDto == null)
            return NotFound();

        return Ok(historialDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHistorialesMedicos()
    {
        var historialesDto = await _historialService.GetAllHistorialesMedicosAsync();
        return Ok(historialesDto);
    }

        [HttpPut("{id}")]
        public IActionResult ActualizarHistorial(int id, [FromBody] HistorialMedicoUpdateDTO historialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _historialService.ActualizarHistorial(id, historialDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarHistorial(int id)
        {
            var eliminado = _historialService.EliminarHistorial(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
