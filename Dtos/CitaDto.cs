public class CitaDto
{
    public int Id { get; set; }
    public int MascotaId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public required string Estado { get; set; }
}
