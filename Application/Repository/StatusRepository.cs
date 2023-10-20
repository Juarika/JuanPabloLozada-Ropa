using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class StatusRepository : GenericRepository<Status>, IStatus
{
    private readonly SkelettonContext _context;

    public StatusRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}