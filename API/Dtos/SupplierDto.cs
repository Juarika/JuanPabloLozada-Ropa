using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class SupplierDto
{
    [Required]
    public string Nit { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int PersonTypeId { get; set; }
    [Required]
    public int CityId { get; set; }
}