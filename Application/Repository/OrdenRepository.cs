using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class OrdenRepository : GenericRepository<Orden>, IOrden
{
    private readonly SkelettonContext _context;

    public OrdenRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}