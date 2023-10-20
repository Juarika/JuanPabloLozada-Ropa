using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class DressInputRepository : IDressInput
{
    private readonly SkelettonContext _context;

    public DressInputRepository(SkelettonContext context)
    {
       _context = context;
    }
    public virtual void Add(DressInput entity)
    {
        _context.Set<DressInput>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<DressInput> entities)
    {
        _context.Set<DressInput>().AddRange(entities);
    }

    public virtual IEnumerable<DressInput> Find(Expression<Func<DressInput, bool>> expression)
    {
        return _context.Set<DressInput>().Where(expression);
    }

    public virtual async Task<IEnumerable<DressInput>> GetAllAsync()
    {
        return await _context.Set<DressInput>().ToListAsync();
    }
    public virtual async Task<DressInput> GetByIdAsync(int id)
    {
        return await _context.Set<DressInput>().FindAsync(id);
    }
    public virtual async Task<DressInput> GetByIdAsync(string id)
    {
       return await _context.Set<DressInput>().FindAsync(id);
    }
    public virtual void Remove(DressInput entity)
    {
        _context.Set<DressInput>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<DressInput> entities)
    {
        _context.Set<DressInput>().RemoveRange(entities);
    }
    public virtual void Update(DressInput entity)
    {
        _context.Set<DressInput>()
            .Update(entity);
    }
}