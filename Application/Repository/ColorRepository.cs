using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ColorRepository : GenericRepository<Color>, IColor
{
    private readonly SkelettonContext _context;

    public ColorRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}