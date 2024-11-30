namespace PetPalzAPI.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public required string Especie { get; set; }
        public string? Raza { get; set; }
        public double Peso { get; set; }
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
        public ICollection<HistorialMedico> HistorialesMedicos { get; set; } = new List<HistorialMedico>();

        public ICollection<Recordatorio>? Recordatorios { get; set; }
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
