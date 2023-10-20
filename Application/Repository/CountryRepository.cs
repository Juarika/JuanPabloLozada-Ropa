using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class CountryRepository : GenericRepository<Country>, ICountry
{
    private readonly SkelettonContext _context;

    public CountryRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}