using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SkelettonContext : DbContext
{
    public SkelettonContext(DbContextOptions options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> UserRoles { get; set; }
    public DbSet<Amount> Amounts { get; set; }
    public DbSet<AmountDetail> AmountDetails { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<PersonType> PersonTypes { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<DetailOrder> DetailOrders { get; set; }
    public DbSet<Dress> Dresses { get; set; }
    public DbSet<DressInput> DressInputs { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Inventary> Inventories { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<ProtectionType> ProtectionTypes { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierInput> SupplierInputs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}