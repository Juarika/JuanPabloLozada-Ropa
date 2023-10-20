using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class CompanyRepository : GenericRepository<Company>, ICompany
{
    private readonly SkelettonContext _context;

    public CompanyRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}