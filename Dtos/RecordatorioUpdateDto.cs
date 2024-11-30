using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class RecordatorioUpdateDTO
    {
        public string? Tipo { get; set; } // Ejemplo: "Vacuna", "Desparasitación"

        public DateTime Fecha { get; set; }

        public string? Notificacion { get; set; } // Texto del recordatorio

        public bool? Recurrente { get; set; } // Indica si es recurrente

        public DateTime FechaUtc => DateTime.SpecifyKind(Fecha, DateTimeKind.Utc);
    }
}
