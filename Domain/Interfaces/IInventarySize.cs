using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IInventarySize
{ 
    Task<InventarySize> GetByIdAsync(int id);
    Task<IEnumerable<InventarySize>> GetAllAsync();
    IEnumerable<InventarySize> Find(Expression<Func<InventarySize, bool>> expression);
    void Add(InventarySize entity);
    void AddRange(IEnumerable<InventarySize> entities);
    void Remove(InventarySize entity);
    void RemoveRange(IEnumerable<InventarySize> entities);
    void Update(InventarySize entity);
}