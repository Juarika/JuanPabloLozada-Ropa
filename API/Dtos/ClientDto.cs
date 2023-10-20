using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ClientDto
{
    public string ClientId { get; set; }
    public string Name { get; set; }
    public DateOnly RegisterDate { get; set; }
    public int PersonTypeId { get; set; }
    public int CityId { get; set; }
}