using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InventaryRepository : GenericRepository<Inventary>, IInventary
{
    private readonly SkelettonContext _context;

    public InventaryRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}