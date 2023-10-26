using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrden : IGenericRepository<Orden>
{ 
    Task<IEnumerable<Orden>> GetForStatus(string name);
    Task<IEnumerable<object>> GetOrdens(int id);
}