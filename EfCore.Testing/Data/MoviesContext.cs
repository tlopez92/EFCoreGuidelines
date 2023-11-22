using EfCore.Testing.Data.EntityMapping;
using EfCore.Testing.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Testing.Data;

public class MoviesContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=MoviesDb; User Id=sa;Password=Password123;TrustServerCertificate=True");
        // Not proper logging
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping());
        modelBuilder.ApplyConfiguration(new MovieMapping());
    }
}