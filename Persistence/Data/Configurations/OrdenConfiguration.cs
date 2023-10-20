using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("Orden");

        builder.Property(p => p.Date)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.Employee)
            .WithMany(p => p.Ordens)
            .HasForeignKey(p => p.EmployeeId);

        builder.HasOne(p => p.Client)
            .WithMany(p => p.Ordens)
            .HasForeignKey(p => p.ClientId);

        builder.HasOne(p => p.Status)
            .WithMany(p => p.Ordens)
            .HasForeignKey(p => p.StatusId);
    }
}