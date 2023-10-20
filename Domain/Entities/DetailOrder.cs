namespace Domain.Entities;

public class DetailOrder : BaseEntity
{
    public int QuantityProduce { get; set; }
    public int QuantityProduced { get; set; }
    public int OrdenId { get; set; }
    public Orden Orden { get; set; }
    public int DressId { get; set; }
    public Dress Dress { get; set; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
}