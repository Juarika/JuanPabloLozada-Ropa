using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class StateDto
{
    public string Name { get; set; }
    public int CountryId { get; set; }
}