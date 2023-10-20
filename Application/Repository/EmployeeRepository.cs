using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EmployeeRepository : GenericRepository<Employee>, IEmployee
{
    private readonly SkelettonContext _context;

    public EmployeeRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}