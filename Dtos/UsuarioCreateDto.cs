using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class UsuarioCreateDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Contraseña { get; set; }
    }
}
