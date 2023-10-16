using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class ContextoDB : DbContext
{
    public DbSet<EstudianteUnab> Estudiante { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-NIOSHCM;Database=Progra2;Trusted_Connection=True;");
    }
}