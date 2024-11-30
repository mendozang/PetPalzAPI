using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class MascotaService
    {
        private readonly AppDbContext _context;

        public MascotaService(AppDbContext context)
        {
            _context = context;
        }

        public Mascota CrearMascota(MascotaCreateDTO mascotaDto)
        {
            var mascota = new Mascota
            {
                Nombre = mascotaDto.Nombre,
                Especie = mascotaDto.Especie,
                Raza = mascotaDto.Raza,
                FechaNacimiento = mascotaDto.FechaNacimiento,
                UsuarioId = mascotaDto.UsuarioId,
                Usuario = _context.Usuarios?.FirstOrDefault(u => u.Id == mascotaDto.UsuarioId) ?? throw new InvalidOperationException("Usuario not found")
            };

            _context.Mascotas.Add(mascota);
            _context.SaveChanges();

            return mascota;
        }

        public async Task<List<MascotaDto>> GetAllMascotasAsync()
    {
        return await _context.Mascotas
            .Select(m => new MascotaDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Especie = m.Especie,
                UsuarioId = m.UsuarioId
            }).ToListAsync();
    }

        public async Task<MascotaDto> GetMascotaByIdAsync(int id)
    {
        var mascota = await _context.Mascotas
            .FirstOrDefaultAsync(m => m.Id == id);

        if (mascota == null) return null;

        return new MascotaDto
        {
            Id = mascota.Id,
            Nombre = mascota.Nombre,
            Especie = mascota.Especie,
            UsuarioId = mascota.UsuarioId
        };
    }

        public bool ActualizarMascota(int id, MascotaUpdateDTO mascotaDto)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null) return false;

            if (!string.IsNullOrEmpty(mascotaDto.Nombre))
                mascota.Nombre = mascotaDto.Nombre;

            if (!string.IsNullOrEmpty(mascotaDto.Especie))
                mascota.Especie = mascotaDto.Especie;

            if (!string.IsNullOrEmpty(mascotaDto.Raza))
                mascota.Raza = mascotaDto.Raza;

            if (mascotaDto.FechaNacimiento != default(DateTime))
                mascota.FechaNacimiento = mascotaDto.FechaNacimiento;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarMascota(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null) return false;

            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();
            return true;
        }
    }
}
