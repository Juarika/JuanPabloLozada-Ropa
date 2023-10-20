namespace Domain.Entities;

public class Size : BaseEntity
{
    public string Description { get; set; }
    public ICollection<InventarySize> InventarySizes { get; set; } 
    public ICollection<AmountDetail> AmountDetails { get; set; }
    public ICollection<Inventary> Inventories { get; set; }  = new HashSet<Inventary>();
}