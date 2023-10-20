using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class StateRepository : GenericRepository<State>, IState
{
    private readonly SkelettonContext _context;

    public StateRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}