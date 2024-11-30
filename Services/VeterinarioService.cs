using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class VeterinarioService
    {
        private readonly AppDbContext _context;

        public VeterinarioService(AppDbContext context)
        {
            _context = context;
        }

        public Veterinario CrearVeterinario(VeterinarioCreateDTO dto)
        {
            var veterinario = new Veterinario
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                InformacionContacto = dto.InformacionContacto,
                Citas = new List<Cita>() // Initialize Citas as an empty list
            };

            _context.Veterinarios.Add(veterinario);
            _context.SaveChanges();
            return veterinario;
        }


        public async Task<VeterinarioDto?> GetVeterinarioByIdAsync(int id)
        {
            var veterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(v => v.Id == id);

            if (veterinario == null) return null;

            return new VeterinarioDto
            {
                Id = veterinario.Id,
                Nombre = veterinario.Nombre,
                Direccion = veterinario.Direccion,
                InformacionContacto = veterinario.InformacionContacto
            };
        }

        public async Task<List<VeterinarioDto>> GetAllVeterinariosAsync()
        {
            return await _context.Veterinarios
                .Select(v => new VeterinarioDto
                {
                    Id = v.Id,
                    Nombre = v.Nombre,
                    Direccion = v.Direccion,
                    InformacionContacto = v.InformacionContacto
                }).ToListAsync();
        }

        public bool ActualizarVeterinario(int id, VeterinarioUpdateDTO dto)
        {
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario == null) return false;

            if (!string.IsNullOrEmpty(dto.Nombre))
                veterinario.Nombre = dto.Nombre;

            if (!string.IsNullOrEmpty(dto.Direccion))
                veterinario.Direccion = dto.Direccion;

            if (!string.IsNullOrEmpty(dto.InformacionContacto))
                veterinario.InformacionContacto = dto.InformacionContacto;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarVeterinario(int id)
        {
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario == null) return false;

            _context.Veterinarios.Remove(veterinario);
            _context.SaveChanges();
            return true;
        }
    }
}
