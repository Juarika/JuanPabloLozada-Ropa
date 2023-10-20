namespace Domain.Entities;

public class AmountDetail : BaseEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int AmountId { get; set; }
    public Amount Amount { get; set; }
    public int InventaryId { get; set; }
    public Inventary Inventary { get; set; }
    public int SizeId { get; set; }
    public Size Size { get; set; }
}