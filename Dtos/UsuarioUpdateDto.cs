using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class UsuarioUpdateDTO
    {
        [StringLength(50, MinimumLength = 3)]
        public required string Nombre { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(6)]
        public required string NuevaContraseña { get; set; }
    }
}
