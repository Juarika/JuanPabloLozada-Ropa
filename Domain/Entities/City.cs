namespace Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Company> Companies { get; set; }
    public ICollection<Client> Clients { get; set; }
    public ICollection<Supplier> Suppliers { get; set; }
}