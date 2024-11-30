using System.ComponentModel.DataAnnotations;
using PetPalzAPI.Models;

namespace PetPalzAPI.DTOs
{
    public class HistorialMedicoCreateDTO
    {
        [Required]
        public int MascotaId { get; set; } // Relación con la mascota

        public string? Vacunas { get; set; } // Ejemplo: "Rabia, Parvovirus"

        public string? Enfermedades { get; set; } // Ejemplo: "Dermatitis, Gripe"

        public string? Tratamientos { get; set; } // Ejemplo: "Antibióticos, Baños medicados"
    }
}
