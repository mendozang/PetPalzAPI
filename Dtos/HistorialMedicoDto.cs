public class HistorialMedicoDto
    {
        public int Id { get; set; }

        public string? Vacunas { get; set; } // Ejemplo: "Rabia, Parvovirus"

        public string? Enfermedades { get; set; } // Ejemplo: "Dermatitis, Gripe"

        public string? Tratamientos { get; set; } // Ejemplo: "Antibióticos, Baños medicados"

        public int MascotaId { get; set; }
    }