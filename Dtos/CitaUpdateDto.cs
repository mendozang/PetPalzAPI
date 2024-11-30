using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class CitaUpdateDTO
    {
        public DateTime Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        public string? Estado { get; set; } // Ejemplo: "Completada"

        public DateTime FechaUtc => DateTime.SpecifyKind(Fecha, DateTimeKind.Utc);
    }
}
