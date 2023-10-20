namespace Domain.Entities;

public class SupplierInput
{
    public int InputId { get; set; }
    public Input Input { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}