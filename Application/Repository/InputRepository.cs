using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InputRepository : GenericRepository<Input>, IInput
{
    private readonly SkelettonContext _context;

    public InputRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}