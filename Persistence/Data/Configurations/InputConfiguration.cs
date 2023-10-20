using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class InputConfiguration : IEntityTypeConfiguration<Input>
{
    public void Configure(EntityTypeBuilder<Input> builder)
    {
        builder.ToTable("Input");

        builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.Value)
        .HasColumnType("decimal")
        .IsRequired();

        builder.Property(p => p.MinStock)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.MaxStock)
        .HasColumnType("int")
        .IsRequired();
    }
}