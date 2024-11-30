using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class HistorialMedico
    {
        public int Id { get; set; }

        public string? Vacunas { get; set; } // Ejemplo: "Rabia, Parvovirus"

        public string? Enfermedades { get; set; } // Ejemplo: "Dermatitis, Gripe"

        public string? Tratamientos { get; set; } // Ejemplo: "Antibióticos, Baños medicados"

        [Required]
        public int MascotaId { get; set; }

        [Required]
        public required Mascota Mascota { get; set; } // Relación con la mascota
    }
}
