using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DressConfiguration : IEntityTypeConfiguration<Dress>
{
    public void Configure(EntityTypeBuilder<Dress> builder)
    {
        builder.ToTable("Dress");

        builder.Property(p => p.Name)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.ValueCop)
        .HasColumnType("decimal")
        .IsRequired();

        builder.Property(p => p.ValueUsd)
        .HasColumnType("decimal")
        .IsRequired();

        builder.HasOne(p => p.ProtectionType)
            .WithMany(p => p.Dresses)
            .HasForeignKey(p => p.ProtectionTypeId);

        builder.HasOne(p => p.Gender)
            .WithMany(p => p.Dresses)
            .HasForeignKey(p => p.GenderId);

        builder.HasOne(p => p.Status)
            .WithMany(p => p.Dresses)
            .HasForeignKey(p => p.StatusId);

        builder
       .HasMany(p => p.Inputs)
       .WithMany(r => r.Dresses)
       .UsingEntity<DressInput>(
           j => j
           .HasOne(pt => pt.Input)
           .WithMany(t => t.DressInputs)
           .HasForeignKey(ut => ut.InputId),
           j => j
           .HasOne(et => et.Dress)
           .WithMany(et => et.DressInputs)
           .HasForeignKey(el => el.DressId),
           j =>
           {
               j.HasKey(t => new { t.DressId, t.InputId });
           });
    }
}