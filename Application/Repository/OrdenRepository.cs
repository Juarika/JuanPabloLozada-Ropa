using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class OrdenRepository : GenericRepository<Orden>, IOrden
{
    private readonly SkelettonContext _context;

    public OrdenRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<Orden>> GetForStatus(string status)
    {
        return await _context.Set<Orden>()
            .Where(e => e.Status.StatusType.Description.ToLower() == status.ToLower())
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetOrdens(int _id)
    {
        var ordens = await _context.Ordens.ToListAsync();
        var cities = await _context.Cities.ToListAsync();
        var clients = await _context.Clients.ToListAsync();
        var detailOrders = await _context.DetailOrders.ToListAsync();
        var statuses = await _context.Statuses.ToListAsync();
        var dresses = await _context.Dresses.ToListAsync();
        var statusTypes = await _context.StatusTypes.ToListAsync();
        var search = (from client in clients
                            join city in cities on client.CityId equals city.Id
                            join orden in ordens on client.Id equals orden.ClientId
                            join status in statuses on orden.StatusId equals status.Id
                            join statusType in statusTypes on status.StatusTypeId equals statusType.Id
                            join detailOrder in detailOrders on orden.Id equals detailOrder.OrdenId
                            join dress in dresses on detailOrder.DressId equals dress.Id
                            select client)
                            .Where(s => s.Id == _id)
                                .Select(s => new
                                {
                                    ClientId = s.Id,
                                    ClientName = s.Name, 
                                    ClientCity = s.City.Name,
                                    OrdenId = s.Ordens.Select(u => u.Id).First(),
                                    OrdenDate = s.Ordens.Select(u => u.Date).First(),
                                    StatusDescription = s.Ordens.Select(u => u.Status.Description).First(),
                                    StatusCode = s.Ordens.Select(u => u.Status.StatusType.Description).First(),
                                    OrdenValue = s.Ordens.Select(u => u.DetailOrders.Select(u => u.QuantityProduced * u.Dress.ValueCop).First()).First(),
                                    DressName = s.Ordens.Select(u => u.DetailOrders.Select(u => u.Dress.Name).First()).First(),
                                    DressCode = s.Ordens.Select(u => u.DetailOrders.Select(u => u.Dress.Id).First()).First(),
                                    DressQuantity = s.Ordens.Select(u => u.DetailOrders.Select(u => u.QuantityProduce).First()).First(),
                                    DressValueCop = s.Ordens.Select(u => u.DetailOrders.Select(u => u.Dress.ValueCop).First()).First(),
                                    DressValueUsd = s.Ordens.Select(u => u.DetailOrders.Select(u => u.Dress.ValueUsd).First()).First(),
                                }).ToList();

        return search;
    }
}