using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class VeterinarioCreateDTO
    {
        [Required]
        public required string Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? InformacionContacto { get; set; } // Teléfono, email, etc.
    }
}
