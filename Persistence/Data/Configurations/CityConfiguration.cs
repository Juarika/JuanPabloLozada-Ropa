using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");

        builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();

        builder.HasOne(p => p.State)
            .WithMany(p => p.Cities)
            .HasForeignKey(p => p.StateId);
    }
}