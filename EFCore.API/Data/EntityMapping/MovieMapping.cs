using EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.API.Data.EntityMapping;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .ToTable("Movies")
            .HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(m => m.ReleaseDate)
            .HasColumnType("date");

        builder.Property(m => m.Synopsis)
            .HasColumnType("varchar(max)")
            .HasColumnName("Plot");

        builder
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasPrincipalKey(g => g.Id)
            .HasForeignKey(m => m.MainGenreId);
        
        // Seed - data that needs to be created always
        builder.HasData(new Movie
        {
            Id = 1,
            Title = "The Shawshank Redemption",
            ReleaseDate = new DateTime(1994, 9, 22),
            Synopsis = "Morgan Freeman and Tim Robbins star in this classic prison drama.",
            MainGenreId = 1
        });
    }
}