namespace Domain.Entities;

public class PersonType : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Supplier> Suppliers { get; set; }    
    public ICollection<Client> Clients { get; set; }    
}