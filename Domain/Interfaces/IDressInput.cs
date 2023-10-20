using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IDressInput
{ 
    Task<DressInput> GetByIdAsync(int id);
    Task<IEnumerable<DressInput>> GetAllAsync();
    IEnumerable<DressInput> Find(Expression<Func<DressInput, bool>> expression);
    void Add(DressInput entity);
    void AddRange(IEnumerable<DressInput> entities);
    void Remove(DressInput entity);
    void RemoveRange(IEnumerable<DressInput> entities);
    void Update(DressInput entity);
}