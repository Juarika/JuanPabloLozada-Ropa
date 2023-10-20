namespace Domain.Entities;

public class Supplier : BaseEntity
{
    public string Nit { get; set; }
    public string Name { get; set; }
    public int PersonTypeId { get; set; }
    public PersonType PersonType { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public ICollection<Input> Inputs { get; set; }  = new HashSet<Input>();
    public ICollection<SupplierInput> SupplierInputs { get; set; }
}