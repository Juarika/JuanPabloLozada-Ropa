using System.ComponentModel.DataAnnotations;

namespace API.Dtos;
public class AmountDto
{
    public DateOnly Date { get; set; }
    public int EmployeeId { get; set; }
    public int ClientId { get; set; }
    public int PaymentMethodId { get; set; }
}