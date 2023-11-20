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
    }
}