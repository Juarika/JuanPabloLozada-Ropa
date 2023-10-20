using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class InputDto
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
}