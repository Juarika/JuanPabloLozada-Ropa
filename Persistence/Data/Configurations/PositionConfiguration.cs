using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Position");

        builder.Property(p => p.Description)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.BaseSalary)
        .HasColumnType("decimal")
        .IsRequired();
    }
}