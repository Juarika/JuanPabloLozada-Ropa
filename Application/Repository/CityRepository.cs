using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class CityRepository : GenericRepository<City>, ICity
{
    private readonly SkelettonContext _context;

    public CityRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}