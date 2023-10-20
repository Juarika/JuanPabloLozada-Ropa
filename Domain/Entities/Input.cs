namespace Domain.Entities;

public class Input : BaseEntity
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
    public ICollection<Dress> Dresses { get; set; } = new HashSet<Dress>();
    public ICollection<DressInput> DressInputs { get; set; }
    public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    public ICollection<SupplierInput> SupplierInputs { get; set; }
    
}