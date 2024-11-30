public class MascotaDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Especie { get; set; }
        public int UsuarioId { get; set; }
    }