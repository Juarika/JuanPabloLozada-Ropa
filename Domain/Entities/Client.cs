namespace Domain.Entities;

public class Client : BaseEntity
{
    public string ClientId { get; set; }
    public string Name { get; set; }
    public DateOnly RegisterDate { get; set; }
    public int PersonTypeId { get; set; }
    public PersonType PersonType { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public ICollection<Amount> Amounts { get; set; }
    public ICollection<Orden> Ordens { get; set; }
}