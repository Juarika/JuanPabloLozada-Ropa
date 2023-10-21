using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class DressDto
{
    public string Name { get; set; }
    public decimal ValueCop { get; set; }
    public decimal ValueUsd { get; set; }
    public int StatusId { get; set; }
    public int ProtectionTypeId { get; set; }
    public int GenderId { get; set; }
}
public class DressWithTotalDto
{
    public string Name { get; set; }
    public int Total { get; set; }
    public ICollection<InputNameDto> Inputs { get; set; }
}