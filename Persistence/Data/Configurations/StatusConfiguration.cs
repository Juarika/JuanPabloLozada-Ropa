using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Status");

        builder.Property(p => p.Description)
        .HasMaxLength(255)
        .IsRequired();

        builder.HasOne(p => p.StatusType)
            .WithMany(p => p.Statuses)
            .HasForeignKey(p => p.StatusTypeId);
    }
}