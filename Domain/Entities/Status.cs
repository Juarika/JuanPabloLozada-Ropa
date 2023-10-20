namespace Domain.Entities;

public class Status : BaseEntity
{
    public string Description { get; set; }
    public int StatusTypeId { get; set; }
    public StatusType StatusType { get; set; }
    public ICollection<Dress> Dresses { get; set; }
    public ICollection<Orden> Ordens { get; set; }
    public ICollection<DetailOrder> DetailOrders { get; set; }
}