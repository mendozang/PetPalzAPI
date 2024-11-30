using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class MascotaCreateDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public required string Especie { get; set; }

        [Required]
        public string? Raza { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int UsuarioId { get; set; } // Relación con el usuario

        public DateTime FechaUtc => DateTime.SpecifyKind(FechaNacimiento, DateTimeKind.Utc);
    }
}
