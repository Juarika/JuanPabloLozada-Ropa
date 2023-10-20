using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AmountConfiguration : IEntityTypeConfiguration<Amount>
{
    public void Configure(EntityTypeBuilder<Amount> builder)
    {
        builder.ToTable("Amount");

        builder.Property(p => p.Date)
        .HasColumnType("date")
        .IsRequired();
        
        builder.HasOne(p => p.Employee)
            .WithMany(p => p.Amounts)
            .HasForeignKey(p => p.EmployeeId);

        builder.HasOne(p => p.Client)
            .WithMany(p => p.Amounts)
            .HasForeignKey(p => p.ClientId);

        builder.HasOne(p => p.PaymentMethod)
            .WithMany(p => p.Amounts)
            .HasForeignKey(p => p.PaymentMethodId);
    }
}