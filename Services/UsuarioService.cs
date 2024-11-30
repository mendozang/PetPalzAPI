using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public Usuario CrearUsuario(UsuarioCreateDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Email = usuarioDto.Email,
                Contraseña = usuarioDto.Contraseña // Aquí puedes cifrar la contraseña
            };

            if (_context != null)
            {
                if (_context.Usuarios != null)
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                }
            }

            return usuario;
        }

        public async Task<List<UsuarioDto>> GetAllUsuariosAsync()
    {
        return await _context.Usuarios
            .Include(u => u.Mascotas)
            .Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Mascotas = u.Mascotas.Select(m => new MascotaDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                }).ToList()
            }).ToListAsync();
    }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Mascotas) // Incluir las mascotas
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null) return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Mascotas = usuario.Mascotas.Select(m => new MascotaDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Especie = m.Especie
            }).ToList()
        };}

        public bool ActualizarUsuario(int id, UsuarioUpdateDTO usuarioDto)
        {
            var usuario = _context.Usuarios?.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;

            if (!string.IsNullOrEmpty(usuarioDto.Nombre))
                usuario.Nombre = usuarioDto.Nombre;

            if (!string.IsNullOrEmpty(usuarioDto.Email))
                usuario.Email = usuarioDto.Email;

            if (!string.IsNullOrEmpty(usuarioDto.NuevaContraseña))
                usuario.Contraseña = usuarioDto.NuevaContraseña; // Aquí también puedes cifrar

            _context.SaveChanges();
            return true;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios?.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;

            if (_context.Usuarios != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
