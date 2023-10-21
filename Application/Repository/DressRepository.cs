using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class DressRepository : GenericRepository<Dress>, IDress
{
    private readonly SkelettonContext _context;

    public DressRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<object>> TotalInputs(int _id)
    {
        var dresses = await _context.Dresses.ToListAsync();
        var inputs = await _context.Inputs.ToListAsync();
        var dressInputs = await _context.DressInputs.ToListAsync();

        var search = (from dress in dresses
                        join dressInput in dressInputs on dress.Id equals dressInput.DressId
                        join input in inputs on dressInput.InputId equals input.Id
                        select dress)
                                .Select(s => new
                                {
                                    DressId = s.Id,
                                    Inputs = s.Inputs,
                                    Total = s.Inputs.Select(u => u.Value)
                                });
        return search;

        // return await _context.Set<Dress>()
        //     .Where(e => e.Id == _id)
        //     .Include(e => e.Inputs)
        //     .Include(e => e.DressInputs.Select(u => u.Quantity))
        //     .ToListAsync();
    }
}