using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class GenderRepository : GenericRepository<Gender>, IGender
{
    private readonly SkelettonContext _context;

    public GenderRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}