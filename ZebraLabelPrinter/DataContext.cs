// DataContext.cs
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class DataContext : DbContext
{
    // Define la propiedad para la tabla de Cajeros en la base de datos
    public DbSet<Cajero> Cajeros { get; set; }

    // Método para configurar la base de datos SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // La base de datos se creará como un archivo llamado 'cajeros.db'
        // en la carpeta de la aplicación.
        optionsBuilder.UseSqlite("Data Source=cajeros.db");
    }
}

