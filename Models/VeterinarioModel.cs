using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Veterinario
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? InformacionContacto { get; set; } // Teléfono, email, etc.

        public required ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
