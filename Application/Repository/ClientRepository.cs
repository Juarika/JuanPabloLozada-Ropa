using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ClientRepository : GenericRepository<Client>, IClient
{
    private readonly SkelettonContext _context;

    public ClientRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}