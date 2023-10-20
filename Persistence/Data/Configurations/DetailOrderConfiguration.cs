using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DetailOrderConfiguration : IEntityTypeConfiguration<DetailOrder>
{
    public void Configure(EntityTypeBuilder<DetailOrder> builder)
    {
        builder.ToTable("DetailOrder");

        builder.Property(p => p.QuantityProduce)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.QuantityProduced)
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Orden)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.OrdenId);

        builder.HasOne(p => p.Dress)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.DressId);

        builder.HasOne(p => p.Color)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.ColorId);

        builder.HasOne(p => p.Status)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.StatusId);
    }
}