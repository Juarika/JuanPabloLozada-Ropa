using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.Property(p => p.EmpId)
        .HasMaxLength(100)
        .IsRequired();

        builder.HasIndex(p => p.EmpId)
        .IsUnique();

        builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.AdmissionDate)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.PositionId);

        builder.HasOne(p => p.City)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.CityId);   
    }
}