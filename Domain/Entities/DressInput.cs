namespace Domain.Entities;

public class DressInput
{
    public int InputId { get; set; }
    public Input Input { get; set; }
    public int DressId { get; set; }
    public Dress Dress { get; set; }
    public int Quantity { get; set; }
}