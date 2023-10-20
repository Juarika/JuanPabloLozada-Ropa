namespace Domain.Entities;

public class Amount : BaseEntity
{
    public DateOnly Date { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public ICollection<AmountDetail> AmountDetails { get; set; }
}