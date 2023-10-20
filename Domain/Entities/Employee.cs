namespace Domain.Entities;

public class Employee : BaseEntity
{
    public string EmpId { get; set; }
    public string Name { get; set; }
    public DateOnly AdmissionDate { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public ICollection<Orden> Ordens { get; set; }
    public ICollection<Amount> Amounts { get; set; }
}