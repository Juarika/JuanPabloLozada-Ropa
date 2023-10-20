using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AmountDetailConfiguration : IEntityTypeConfiguration<AmountDetail>
{
    public void Configure(EntityTypeBuilder<AmountDetail> builder)
    {
        builder.ToTable("AmountDetail");
    
        builder.Property(p => p.Quantity)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Price)
        .HasColumnType("decimal")
        .IsRequired();

        builder.HasOne(p => p.Amount)
            .WithMany(p => p.AmountDetails)
            .HasForeignKey(p => p.AmountId);

        builder.HasOne(p => p.Inventary)
            .WithMany(p => p.AmountDetails)
            .HasForeignKey(p => p.InventaryId);

        builder.HasOne(p => p.Size)
            .WithMany(p => p.AmountDetails)
            .HasForeignKey(p => p.SizeId);
        }
}