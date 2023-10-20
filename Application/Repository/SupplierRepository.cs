using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class SupplierRepository : GenericRepository<Supplier>, ISupplier
{
    private readonly SkelettonContext _context;

    public SupplierRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}