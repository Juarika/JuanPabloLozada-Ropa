namespace Domain.Entities;

public class Orden : BaseEntity
{
    public DateOnly Date { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public ICollection<DetailOrder> DetailOrders { get; set; }
}