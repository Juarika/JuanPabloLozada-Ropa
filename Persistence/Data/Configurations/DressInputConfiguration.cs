using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DressInputConfiguration : IEntityTypeConfiguration<DressInput>
{
    public void Configure(EntityTypeBuilder<DressInput> builder)
    {
        builder.ToTable("DressInput");

        builder.Property(p => p.Quantity)
        .HasColumnType("int")
        .IsRequired();
    }
}