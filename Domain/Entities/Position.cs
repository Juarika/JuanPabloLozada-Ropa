namespace Domain.Entities;

public class Position : BaseEntity
{
    public string Description { get; set; }
    public decimal BaseSalary { get; set; }
    public ICollection<Employee> Employees { get; set; }
}