using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
{
    private readonly SkelettonContext _context;

    public PersonTypeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}