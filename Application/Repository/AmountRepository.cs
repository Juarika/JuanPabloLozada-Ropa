using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class AmountRepository : GenericRepository<Amount>, IAmount
{
    private readonly SkelettonContext _context;

    public AmountRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}