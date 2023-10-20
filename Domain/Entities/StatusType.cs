namespace Domain.Entities;

public class StatusType : BaseEntity
{
    public string Description { get; set; }
    public ICollection<Status> Statuses { get; set; }
}