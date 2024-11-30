public class RecordatorioDto
{
    public int Id { get; set; }

    public required string Tipo { get; set; } // Ejemplo: "Vacuna", "Desparasitación"
    public DateTime Fecha { get; set; }
    public string? Notificacion { get; set; } // Texto del recordatorio
    public bool Recurrente { get; set; } // Indica si es recurrente
    public int MascotaId { get; set; }
}