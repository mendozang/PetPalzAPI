using Microsoft.EntityFrameworkCore;
using PetPalzAPI.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PetPalzAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Recordatorio> Recordatorios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                            v => v.ToUniversalTime(), // Almacena como UTC
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Convierte al leer
                        ));
                    }

                    if (property.ClrType == typeof(DateTimeOffset))
                    {
                        property.SetValueConverter(new ValueConverter<DateTimeOffset, DateTimeOffset>(
                            v => v.ToUniversalTime(), // Almacena como UTC
                            v => v.ToUniversalTime() // Convierte al leer
                        ));
                    }
                }
                // Relación Usuario-Mascotas
                modelBuilder.Entity<Usuario>()
                    .HasMany(u => u.Mascotas)
                    .WithOne(m => m.Usuario)
                    .HasForeignKey(m => m.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relación Mascota-Historial Médico
                modelBuilder.Entity<Mascota>()
                    .HasMany(m => m.HistorialesMedicos)
                    .WithOne(h => h.Mascota)
                    .HasForeignKey(h => h.MascotaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relación Mascota-Recordatorio
                modelBuilder.Entity<Mascota>()
                    .HasMany(m => m.Recordatorios)
                    .WithOne(r => r.Mascota)
                    .HasForeignKey(r => r.MascotaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relación Citas-Veterinario
                modelBuilder.Entity<Veterinario>()
                    .HasMany(v => v.Citas)
                    .WithOne(c => c.Veterinario)
                    .HasForeignKey(c => c.VeterinarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relación Cita-Mascota
                modelBuilder.Entity<Cita>()
                    .HasOne(c => c.Mascota)
                    .WithMany(m => m.Citas)
                    .HasForeignKey(c => c.MascotaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relación Cita-Veterinario
                modelBuilder.Entity<Cita>()
                    .HasOne(c => c.Veterinario)
                    .WithMany(v => v.Citas)
                    .HasForeignKey(c => c.VeterinarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}

