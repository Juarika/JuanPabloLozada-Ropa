using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class InventaryDto
{
    public decimal AmountCop { get; set; }
    public decimal AmountUsd { get; set; }
    public int DressId { get; set; }
}