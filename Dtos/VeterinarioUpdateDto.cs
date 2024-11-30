using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class VeterinarioUpdateDTO
    {
        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? InformacionContacto { get; set; } // Teléfono, email, etc.
    }
}
