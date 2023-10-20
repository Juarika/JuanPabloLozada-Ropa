namespace Domain.Entities;

public class Color : BaseEntity
{
    public string Description { get; set; }
    public ICollection<DetailOrder> DetailOrders { get; set; }
}