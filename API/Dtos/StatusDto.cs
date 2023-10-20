using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class StatusDto
{
    public string Description { get; set; }
    public int StatusTypeId { get; set; }
}