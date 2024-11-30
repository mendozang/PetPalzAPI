using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class RecordatorioService
    {
        private readonly AppDbContext _context;

        public RecordatorioService(AppDbContext context)
        {
            _context = context;
        }

        public Recordatorio CrearRecordatorio(RecordatorioCreateDTO recordatorioDto)
        {
            var recordatorio = new Recordatorio
            {
                Tipo = recordatorioDto.Tipo,
                Fecha = recordatorioDto.Fecha,
                Notificacion = recordatorioDto.Notificacion,
                Recurrente = recordatorioDto.Recurrente,
                MascotaId = recordatorioDto.MascotaId
            };

            _context.Recordatorios.Add(recordatorio);
            _context.SaveChanges();

            return recordatorio;
        }

        public async Task<RecordatorioDto> GetRecordatorioByIdAsync(int id)
        {
            var recordatorio = await _context.Recordatorios
                .Include(r => r.Mascota)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recordatorio == null) return null;

            return new RecordatorioDto
            {
                Tipo = recordatorio.Tipo,
                Fecha = recordatorio.Fecha,
                Notificacion = recordatorio.Notificacion,
                Recurrente = recordatorio.Recurrente,
                MascotaId = recordatorio.MascotaId
            };
        }

        public async Task<List<RecordatorioDto>> GetAllRecordatoriosAsync()
        {
            return await _context.Recordatorios
                .Include(r => r.Mascota)
                .Select(r => new RecordatorioDto
                {
                    Id = r.Id,
                    Tipo = r.Tipo,
                    Fecha = r.Fecha,
                    Notificacion = r.Notificacion,
                    Recurrente = r.Recurrente,
                    MascotaId = r.MascotaId,
                }).ToListAsync();
        }

        public bool ActualizarRecordatorio(int id, RecordatorioUpdateDTO recordatorioDto)
        {
            var recordatorio = _context.Recordatorios.FirstOrDefault(r => r.Id == id);
            if (recordatorio == null) return false;

            if (!string.IsNullOrEmpty(recordatorioDto.Tipo))
                recordatorio.Tipo = recordatorioDto.Tipo;

            if (recordatorioDto.Fecha != default(DateTime))
                recordatorio.Fecha = recordatorioDto.Fecha;

            if (!string.IsNullOrEmpty(recordatorioDto.Notificacion))
                recordatorio.Notificacion = recordatorioDto.Notificacion;

            if (recordatorioDto.Recurrente.HasValue)
                recordatorio.Recurrente = recordatorioDto.Recurrente.Value;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarRecordatorio(int id)
        {
            var recordatorio = _context.Recordatorios.FirstOrDefault(r => r.Id == id);
            if (recordatorio == null) return false;

            _context.Recordatorios.Remove(recordatorio);
            _context.SaveChanges();
            return true;
        }
    }
}
