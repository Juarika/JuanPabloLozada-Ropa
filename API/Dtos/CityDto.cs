using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class CityDto
{
    public string Name { get; set; }
    public int StateId { get; set; }
}