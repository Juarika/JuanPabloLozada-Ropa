using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ProtectionTypeConfiguration : IEntityTypeConfiguration<ProtectionType>
{
    public void Configure(EntityTypeBuilder<ProtectionType> builder)
    {
        builder.ToTable("ProtectionType");

        builder.Property(p => p.Description)
        .HasMaxLength(255)
        .IsRequired();
    }
}