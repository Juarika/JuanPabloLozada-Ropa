namespace Domain.Entities;

public class Gender : BaseEntity
{
    public string Description { get; set; }
    public ICollection<Dress> Dresses { get; set; }
}