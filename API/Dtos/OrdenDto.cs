using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class OrdenDto
{
    public DateOnly Date { get; set; }
    public int EmployeeId { get; set; }
    public int ClientId { get; set; }
    public int StatusId { get; set; }
}