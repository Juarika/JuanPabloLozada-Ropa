using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ISupplierInput
{ 
    Task<SupplierInput> GetByIdAsync(int id);
    Task<IEnumerable<SupplierInput>> GetAllAsync();
    IEnumerable<SupplierInput> Find(Expression<Func<SupplierInput, bool>> expression);
    void Add(SupplierInput entity);
    void AddRange(IEnumerable<SupplierInput> entities);
    void Remove(SupplierInput entity);
    void RemoveRange(IEnumerable<SupplierInput> entities);
    void Update(SupplierInput entity);
}