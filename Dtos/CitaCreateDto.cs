using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class CitaCreateDTO
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        public required string Estado { get; set; } // Ejemplo: "Pendiente"

        [Required]
        public int MascotaId { get; set; }

        [Required]
        public int VeterinarioId { get; set; }

        public DateTime FechaUtc => DateTime.SpecifyKind(Fecha, DateTimeKind.Utc);
    }
}
