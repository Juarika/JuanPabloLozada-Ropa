using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class SupplierInputRepository : ISupplierInput
{
    private readonly SkelettonContext _context;

    public SupplierInputRepository(SkelettonContext context)
    {
       _context = context;
    }
    public virtual void Add(SupplierInput entity)
    {
        _context.Set<SupplierInput>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<SupplierInput> entities)
    {
        _context.Set<SupplierInput>().AddRange(entities);
    }

    public virtual IEnumerable<SupplierInput> Find(Expression<Func<SupplierInput, bool>> expression)
    {
        return _context.Set<SupplierInput>().Where(expression);
    }

    public virtual async Task<IEnumerable<SupplierInput>> GetAllAsync()
    {
        return await _context.Set<SupplierInput>().ToListAsync();
    }
    public virtual async Task<SupplierInput> GetByIdAsync(int id)
    {
        return await _context.Set<SupplierInput>().FindAsync(id);
    }
    public virtual async Task<SupplierInput> GetByIdAsync(string id)
    {
       return await _context.Set<SupplierInput>().FindAsync(id);
    }
    public virtual void Remove(SupplierInput entity)
    {
        _context.Set<SupplierInput>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<SupplierInput> entities)
    {
        _context.Set<SupplierInput>().RemoveRange(entities);
    }
    public virtual void Update(SupplierInput entity)
    {
        _context.Set<SupplierInput>()
            .Update(entity);
    }
}