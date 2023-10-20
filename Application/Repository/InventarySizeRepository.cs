using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class InventarySizeRepository : IInventarySize
{
    private readonly SkelettonContext _context;

    public InventarySizeRepository(SkelettonContext context)
    {
       _context = context;
    }
    public virtual void Add(InventarySize entity)
    {
        _context.Set<InventarySize>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<InventarySize> entities)
    {
        _context.Set<InventarySize>().AddRange(entities);
    }

    public virtual IEnumerable<InventarySize> Find(Expression<Func<InventarySize, bool>> expression)
    {
        return _context.Set<InventarySize>().Where(expression);
    }

    public virtual async Task<IEnumerable<InventarySize>> GetAllAsync()
    {
        return await _context.Set<InventarySize>().ToListAsync();
    }
    public virtual async Task<InventarySize> GetByIdAsync(int id)
    {
        return await _context.Set<InventarySize>().FindAsync(id);
    }
    public virtual async Task<InventarySize> GetByIdAsync(string id)
    {
       return await _context.Set<InventarySize>().FindAsync(id);
    }
    public virtual void Remove(InventarySize entity)
    {
        _context.Set<InventarySize>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<InventarySize> entities)
    {
        _context.Set<InventarySize>().RemoveRange(entities);
    }
    public virtual void Update(InventarySize entity)
    {
        _context.Set<InventarySize>()
            .Update(entity);
    }
}