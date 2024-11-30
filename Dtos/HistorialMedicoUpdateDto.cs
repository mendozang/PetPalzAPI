using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class HistorialMedicoUpdateDTO
    {
        public string? Vacunas { get; set; } // Ejemplo: "Rabia, Parvovirus"

        public string? Enfermedades { get; set; } // Ejemplo: "Dermatitis, Gripe"

        public string? Tratamientos { get; set; } // Ejemplo: "Antibióticos, Baños medicados"
    }
}
