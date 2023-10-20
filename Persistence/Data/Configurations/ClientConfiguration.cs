using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.Property(p => p.ClientId)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.RegisterDate)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.PersonType)
            .WithMany(p => p.Clients)
            .HasForeignKey(p => p.PersonTypeId);

        builder.HasOne(p => p.City)
            .WithMany(p => p.Clients)
            .HasForeignKey(p => p.CityId);    
    }
}