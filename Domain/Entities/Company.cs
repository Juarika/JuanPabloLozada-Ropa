namespace Domain.Entities;

public class Company : BaseEntity
{
    public string Nit { get; set; }
    public string BusinessName { get; set; }
    public string LegalRepresentative { get; set; }
    public DateOnly Creationdate { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}