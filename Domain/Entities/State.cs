namespace Domain.Entities;

public class State : BaseEntity
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<City> Cities { get; set; }
}