using EFCore.Migrations.Data.ValueGenerators;
using EFCore.Migrations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Migrations.Data.EntityMapping;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property<DateTime>("CreatedDate")
            .HasColumnName("CreatedAt")
            .HasValueGenerator<CreatedDateGenerator>();
        
        builder.HasData(new Genre { Id = 1, Name = "Drama" });
    }
}