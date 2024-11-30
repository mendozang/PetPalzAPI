using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class CitaService
    {
        private readonly AppDbContext _context;

        public CitaService(AppDbContext context)
        {
            _context = context;
        }

        public Cita CrearCita(CitaCreateDTO dto)
        {
            var cita = new Cita
            {
                Fecha = dto.Fecha,
                Hora = dto.Hora,
                Estado = dto.Estado,
                MascotaId = dto.MascotaId,
                VeterinarioId = dto.VeterinarioId,
                Mascota = _context.Mascotas.FirstOrDefault(m => m.Id == dto.MascotaId),
                Veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == dto.VeterinarioId)
            };

            _context.Citas.Add(cita);
            _context.SaveChanges();
            return cita;
        }

        public async Task<CitaDto> GetCitaByIdAsync(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Mascota)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cita == null) return null;

            // Mapear la entidad a un DTO
            return new CitaDto
            {
                Id = cita.Id,
                MascotaId = cita.MascotaId,
                Fecha = cita.Fecha,
                Hora = cita.Hora,
                Estado = cita.Estado
            };
        }


        public IEnumerable<Cita> ObtenerTodasLasCitas()
        {
            return _context.Citas.ToList();
            
        }

        public bool ActualizarCita(int id, CitaUpdateDTO dto)
        {
            var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
            if (cita == null) return false;

            if (dto.Fecha != default(DateTime))
                cita.Fecha = dto.Fecha;

            if (dto.Hora.HasValue)
                cita.Hora = dto.Hora.Value;

            if (!string.IsNullOrEmpty(dto.Estado))
                cita.Estado = dto.Estado;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarCita(int id)
        {
            var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            _context.SaveChanges();
            return true;
        }
    }
}
