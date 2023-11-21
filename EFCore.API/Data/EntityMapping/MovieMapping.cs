using EFCore.API.Data.ValueConverters;
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
            .HasQueryFilter(m => m.ReleaseDate >= new DateTime(1995, 1, 1))
            .HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(m => m.ReleaseDate)
            .HasColumnType("char(8)")
            .HasConversion(new DateTimeToChar8Converter());

        builder.Property(m => m.Synopsis)
            .HasColumnType("varchar(max)")
            .HasColumnName("Plot");

        builder.Property(m => m.AgeRating)
            .HasColumnType("varchar(32)")
            .HasConversion<string>();

        builder.OwnsOne(m => m.Director)
            .ToTable("Movie_Directors");
        
        builder.OwnsMany(m => m.Actors)
            .ToTable("Movie_Actors");

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
            MainGenreId = 1,
            AgeRating = AgeRating.Adolescent
        });

        builder.OwnsOne(m => m.Director)
            .HasData(new {MovieId = 1, FirstName = "David", LastName = "Fincher"});
        
        builder.OwnsMany(m => m.Actors)
            .HasData(
                new {MovieId = 1, Id = 1, FirstName = "Morgan", LastName = "Freeman"},
                new {MovieId = 1, Id = 2, FirstName = "Tim", LastName = "Robbins"});

    }
}