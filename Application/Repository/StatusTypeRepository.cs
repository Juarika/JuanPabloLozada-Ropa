using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class StatusTypeRepository : GenericRepository<StatusType>, IStatusType
{
    private readonly SkelettonContext _context;

    public StatusTypeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}