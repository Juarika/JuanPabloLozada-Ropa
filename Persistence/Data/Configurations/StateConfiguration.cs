using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");

        builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();

        builder.HasOne(p => p.Country)
            .WithMany(p => p.States)
            .HasForeignKey(p => p.CountryId);
    }
}