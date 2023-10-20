namespace Domain.Entities;

public class Inventary : BaseEntity
{
    public decimal AmountCop { get; set; }
    public decimal AmountUsd { get; set; }
    public int DressId { get; set; }
    public Dress Dress { get; set; }
    public ICollection<InventarySize> InventarySizes { get; set; } 
    public ICollection<AmountDetail> AmountDetails { get; set; } 
    public ICollection<Size> Sizes { get; set; }  = new HashSet<Size>();
}