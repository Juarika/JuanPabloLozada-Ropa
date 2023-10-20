using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class SizeRepository : GenericRepository<Size>, ISize
{
    private readonly SkelettonContext _context;

    public SizeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}