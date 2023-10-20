using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class InventaryConfiguration : IEntityTypeConfiguration<Inventary>
{
    public void Configure(EntityTypeBuilder<Inventary> builder)
    {
        builder.ToTable("Inventary");

        builder.Property(p => p.AmountCop)
        .HasColumnType("decimal")
        .IsRequired();

        builder.Property(p => p.AmountUsd)
        .HasColumnType("decimal")
        .IsRequired();

        builder.HasOne(p => p.Dress)
            .WithMany(p => p.Inventories)
            .HasForeignKey(p => p.DressId);

        builder
       .HasMany(p => p.Sizes)
       .WithMany(r => r.Inventories)
       .UsingEntity<InventarySize>(
           j => j
           .HasOne(pt => pt.Size)
           .WithMany(t => t.InventarySizes)
           .HasForeignKey(ut => ut.SizeId),
           j => j
           .HasOne(et => et.Inventary)
           .WithMany(et => et.InventarySizes)
           .HasForeignKey(el => el.InventaryId),
           j =>
           {
               j.HasKey(t => new { t.InventaryId, t.SizeId });
           });
    }
}