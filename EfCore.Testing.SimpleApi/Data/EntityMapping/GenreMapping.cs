using EfCore.Testing.SimpleApi.Data.ValueGenerators;
using EfCore.Testing.SimpleApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Testing.SimpleApi.Data.EntityMapping;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property<DateTime>("CreatedDate")
            .HasColumnName("CreatedAt")
            .HasValueGenerator<CreatedDateGenerator>();
    }
}