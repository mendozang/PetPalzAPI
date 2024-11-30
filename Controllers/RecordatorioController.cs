using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatorioController : ControllerBase
    {
        private readonly RecordatorioService _recordatorioService;

        public RecordatorioController(RecordatorioService recordatorioService)
        {
            _recordatorioService = recordatorioService;
        }

        [HttpPost]
        public IActionResult CrearRecordatorio([FromBody] RecordatorioCreateDTO recordatorioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recordatorio = _recordatorioService.CrearRecordatorio(recordatorioDto);
            return CreatedAtAction(nameof(GetRecordatorio), new { id = recordatorio.Id }, recordatorio);
        }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetRecordatorio(int id)
    {
        var recordatorioDto = await _recordatorioService.GetRecordatorioByIdAsync(id);

        if (recordatorioDto == null)
            return NotFound();

        return Ok(recordatorioDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecordatorios()
    {
        var recordatoriosDto = await _recordatorioService.GetAllRecordatoriosAsync();
        return Ok(recordatoriosDto);
    }

        [HttpPut("{id}")]
        public IActionResult ActualizarRecordatorio(int id, [FromBody] RecordatorioUpdateDTO recordatorioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _recordatorioService.ActualizarRecordatorio(id, recordatorioDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarRecordatorio(int id)
        {
            var eliminado = _recordatorioService.EliminarRecordatorio(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
