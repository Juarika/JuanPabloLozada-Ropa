using Domain.Entities;

namespace Domain.Interfaces;

public interface IDress : IGenericRepository<Dress>
{ 
    Task<IEnumerable<object>> TotalInputs(int _id);
}