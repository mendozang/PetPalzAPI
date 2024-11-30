using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class RecordatorioCreateDTO
    {
        [Required]
        public required string Tipo { get; set; } // Ejemplo: "Vacuna", "Desparasitación"

        [Required]
        public DateTime Fecha { get; set; }

        public string? Notificacion { get; set; } // Texto del recordatorio

        [Required]
        public bool Recurrente { get; set; } // Indica si es recurrente

        [Required]
        public int MascotaId { get; set; }

        public DateTime FechaUtc => DateTime.SpecifyKind(Fecha, DateTimeKind.Utc);
    }
}
