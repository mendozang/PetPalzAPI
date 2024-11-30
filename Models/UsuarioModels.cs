namespace PetPalzAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public required string Contraseña { get; set; }

        public List<Mascota>? Mascotas { get; set; }
    }
}
