using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ProtectionTypeDto
{
    public string Description { get; set; }
    public ICollection<DressDto> Dresses { get; set; }
}