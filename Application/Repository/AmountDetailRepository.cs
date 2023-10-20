using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class AmountDetailRepository : GenericRepository<AmountDetail>, IAmountDetail
{
    private readonly SkelettonContext _context;

    public AmountDetailRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}