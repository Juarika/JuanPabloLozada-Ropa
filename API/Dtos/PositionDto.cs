using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PositionDto
{
    public string Description { get; set; }
    public decimal BaseSalary { get; set; }
}