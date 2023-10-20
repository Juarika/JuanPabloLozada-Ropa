using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ProtectionTypeRepository : GenericRepository<ProtectionType>, IProtectionType
{
    private readonly SkelettonContext _context;

    public ProtectionTypeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}