using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class MascotaUpdateDTO
    {
        [StringLength(50, MinimumLength = 2)]
        public required string Nombre { get; set; }

        [StringLength(30)]
        public required string Especie { get; set; }

        public string? Raza { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaUtc => DateTime.SpecifyKind(FechaNacimiento, DateTimeKind.Utc);
    }
}
