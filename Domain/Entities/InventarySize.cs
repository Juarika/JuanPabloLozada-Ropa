namespace Domain.Entities;

public class InventarySize
{
    public int InventaryId { get; set; }
    public Inventary Inventary { get; set; }
    public int SizeId { get; set; }
    public Size Size { get; set; } 
    public int Quantity { get; set; }
}