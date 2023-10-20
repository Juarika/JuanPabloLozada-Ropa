namespace Domain.Entities;

public class ProtectionType : BaseEntity
{
    public string Description { get; set; }
    public ICollection<Dress> Dresses { get; set; }
}