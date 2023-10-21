using Domain.Entities;

namespace Domain.Interfaces;

public interface IInput : IGenericRepository<Input>
{ 
    Task<IEnumerable<Input>> GetForSupplier(string search);
}