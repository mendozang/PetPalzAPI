using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; } // Hora de la cita

        [Required]
        public required string Estado { get; set; } // Ejemplo: "Pendiente", "Completada"

        public int MascotaId { get; set; }
        public required Mascota Mascota { get; set; }

        public int VeterinarioId { get; set; }
        public required Veterinario Veterinario { get; set; }
    }
}
