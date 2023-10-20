using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier");

        builder.Property(p => p.Nit)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();

        builder.HasOne(p => p.PersonType)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(p => p.PersonTypeId);

        builder.HasOne(p => p.City)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(p => p.CityId);   

        builder
       .HasMany(p => p.Inputs)
       .WithMany(r => r.Suppliers)
       .UsingEntity<SupplierInput>(
           j => j
           .HasOne(pt => pt.Input)
           .WithMany(t => t.SupplierInputs)
           .HasForeignKey(ut => ut.InputId),
           j => j
           .HasOne(et => et.Supplier)
           .WithMany(et => et.SupplierInputs)
           .HasForeignKey(el => el.SupplierId),
           j =>
           {
               j.ToTable("SupplierInput");
               j.HasKey(t => new { t.SupplierId, t.InputId });
           });
    }
}