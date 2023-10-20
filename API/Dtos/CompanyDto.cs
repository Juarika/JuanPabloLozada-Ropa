using System.ComponentModel.DataAnnotations;

namespace API.Dtos;
public class CompanyDto
{
    public string Nit { get; set; }
    public string BusinessName { get; set; }
    public string LegalRepresentative { get; set; }
    public DateOnly Creationdate { get; set; }
    public int CityId { get; set; }
}