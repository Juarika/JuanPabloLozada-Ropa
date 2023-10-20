using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DressRepository : GenericRepository<Dress>, IDress
{
    private readonly SkelettonContext _context;

    public DressRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}