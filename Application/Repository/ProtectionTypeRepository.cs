using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class ProtectionTypeRepository : GenericRepository<ProtectionType>, IProtectionType
{
    private readonly SkelettonContext _context;

    public ProtectionTypeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<ProtectionType>> GetWithPagination(int pageNumber, int pageSize)
    {
        int startIndex = (pageNumber - 1) * pageSize;

        var paginatedEntities = await _context.Set<ProtectionType>()
            .Include(e => e.Dresses)
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();

        return paginatedEntities;
    }
}