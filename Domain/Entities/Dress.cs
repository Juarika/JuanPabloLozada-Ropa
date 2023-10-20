namespace Domain.Entities;

public class Dress : BaseEntity
{
    public string Name { get; set; }
    public decimal ValueCop { get; set; }
    public decimal ValueUsd { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public int ProtectionTypeId { get; set; }
    public ProtectionType ProtectionType { get; set; }
    public int GenderId { get; set; }
    public Gender Gender { get; set; }
    public ICollection<Inventary> Inventories { get; set; }
    public ICollection<DetailOrder> DetailOrders { get; set; }
    public ICollection<DressInput> DressInputs { get; set; }
    public ICollection<Input> Inputs { get; set; }  = new HashSet<Input>();

}