using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class SupplierRepository : GenericRepository<Supplier>, ISupplier
{
    private readonly SkelettonContext _context;

    public SupplierRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<Supplier>> GetForPersonType(string name)
    {
        return await _context.Set<PersonType>()
            .Where(e => e.Name.ToLower() == name.ToLower())
            .Include(e => e.Suppliers)
            .SelectMany(e => e.Suppliers)
            .Distinct()
            .ToListAsync();
    }
}