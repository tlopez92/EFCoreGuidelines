using EfCore.Testing.Data.ValueGenerators;
using EfCore.Testing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Testing.Data.EntityMapping;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property<DateTime>("CreatedDate")
            .HasColumnName("CreatedAt")
            .HasValueGenerator<CreatedDateGenerator>();
    }
}