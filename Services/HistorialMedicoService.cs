using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class HistorialMedicoService
    {
        private readonly AppDbContext _context;

        public HistorialMedicoService(AppDbContext context)
        {
            _context = context;
        }

        public HistorialMedico CrearHistorial(HistorialMedicoCreateDTO historialDto)
        {
            var historial = new HistorialMedico
            {
                MascotaId = historialDto.MascotaId,
                Mascota = _context.Mascotas.FirstOrDefault(m => m.Id == historialDto.MascotaId),
                Vacunas = historialDto.Vacunas,
                Enfermedades = historialDto.Enfermedades,
                Tratamientos = historialDto.Tratamientos
            };

            _context.HistorialesMedicos.Add(historial);
            _context.SaveChanges();

            return historial;
        }

        public async Task<List<HistorialMedicoDto>> GetAllHistorialesMedicosAsync()
    {
        return await _context.HistorialesMedicos
            .Include(h => h.Mascota)
            .Select(h => new HistorialMedicoDto
            {
                Id = h.Id,
            Vacunas = h.Vacunas,
            Enfermedades = h.Enfermedades,
            Tratamientos = h.Tratamientos,
            MascotaId = h.MascotaId
            }).ToListAsync();
    }

         public async Task<HistorialMedicoDto> GetHistorialMedicoByIdAsync(int id)
    {
        var historialMedico = await _context.HistorialesMedicos
            .Include(h => h.Mascota)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (historialMedico == null) return null;

        return new HistorialMedicoDto
        {
            Id = historialMedico.Id,
            Vacunas = historialMedico.Vacunas,
            Enfermedades = historialMedico.Enfermedades,
            Tratamientos = historialMedico.Tratamientos,
            MascotaId = historialMedico.MascotaId
        };
    }

        public bool ActualizarHistorial(int id, HistorialMedicoUpdateDTO historialDto)
        {
            var historial = _context.HistorialesMedicos.FirstOrDefault(h => h.Id == id);
            if (historial == null) return false;

            if (!string.IsNullOrEmpty(historialDto.Vacunas))
                historial.Vacunas = historialDto.Vacunas;

            if (!string.IsNullOrEmpty(historialDto.Enfermedades))
                historial.Enfermedades = historialDto.Enfermedades;

            if (!string.IsNullOrEmpty(historialDto.Tratamientos))
                historial.Tratamientos = historialDto.Tratamientos;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarHistorial(int id)
        {
            var historial = _context.HistorialesMedicos.FirstOrDefault(h => h.Id == id);
            if (historial == null) return false;

            _context.HistorialesMedicos.Remove(historial);
            _context.SaveChanges();
            return true;
        }
    }
}
