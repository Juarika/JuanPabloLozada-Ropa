using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");

        builder.Property(p => p.Nit)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.BusinessName)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.LegalRepresentative)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p => p.Creationdate)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.City)
            .WithMany(p => p.Companies)
            .HasForeignKey(p => p.CityId);   
    }
}