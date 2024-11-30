using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Recordatorio
    {
        public int Id { get; set; }

        [Required]
        public required string Tipo { get; set; } // Ejemplo: "Vacuna", "Desparasitación"

        [Required]
        public DateTime Fecha { get; set; }

        public string? Notificacion { get; set; } // Texto del recordatorio

        [Required]
        public bool Recurrente { get; set; } // Indica si es recurrente

        [Required]
        public int MascotaId { get; set; }

        [Required]
        public Mascota? Mascota { get; set; }
    }
}
