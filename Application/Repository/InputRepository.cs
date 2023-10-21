using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class InputRepository : GenericRepository<Input>, IInput
{
    private readonly SkelettonContext _context;

    public InputRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
    
    public async Task<IEnumerable<Input>> GetForSupplier(string search)
    {
        return await _context.Set<Supplier>()
            .Where(e => e.Nit.ToLower() == search.ToLower())
            .Include(e => e.Inputs)
            .SelectMany(e => e.Inputs)
            .ToListAsync();
    }

}