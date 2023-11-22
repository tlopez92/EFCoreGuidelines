using EfCore.Testing.SimpleApi.Data.EntityMapping;
using EfCore.Testing.SimpleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Testing.SimpleApi.Data;

public class MoviesContext : DbContext
{
    public MoviesContext() { }
    
    public MoviesContext(DbContextOptions<MoviesContext> options)
        :base(options)
    { }
    
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Not proper logging
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreMapping());
    }
}