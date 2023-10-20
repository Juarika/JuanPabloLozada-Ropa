using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class InventarySizeConfiguration : IEntityTypeConfiguration<InventarySize>
{
    public void Configure(EntityTypeBuilder<InventarySize> builder)
    {
        builder.ToTable("InventarySize");

        builder.Property(p => p.Quantity)
        .HasColumnType("int")
        .IsRequired();
    }
}