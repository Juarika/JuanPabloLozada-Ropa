using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class EmployeeDto
{
    public string EmpId { get; set; }
    public string Name { get; set; }
    public DateOnly AdmissionDate { get; set; }
    public int PositionId { get; set; }
    public int CityId { get; set; }
}