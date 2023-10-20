using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethod
{
    private readonly SkelettonContext _context;

    public PaymentMethodRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}