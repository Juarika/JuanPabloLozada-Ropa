namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRol Roles { get; }
    IUser Users { get; }
    IUserRol UserRoles { get; }
    IAmount Amounts { get; } 
    IAmountDetail AmountDetails { get; } 
    ICity Cities { get; } 
    IPersonType PersonTypes { get; } 
    IClient Clients { get; } 
    IColor Colors { get; } 
    ICompany Companies { get; } 
    ICountry Countries { get; } 
    IDetailOrder DetailOrders { get; } 
    IDress Dresses { get; } 
    IDressInput DressInputs { get; } 
    IEmployee Employees { get; } 
    IGender Genders { get; } 
    IPaymentMethod PaymentMethods { get; } 
    IPosition Positions { get; } 
    IProtectionType ProtectionTypes { get; } 
    ISize Sizes { get; } 
    IState States { get; } 
    IStatus Statuses { get; } 
    IStatusType StatusTypes { get; } 
    ISupplier Suppliers { get; } 
    ISupplierInput SupplierInputs { get; } 
    IInput Inputs { get; } 
    IInventary Inventories { get; } 
    IInventarySize InventarySizes { get; } 
    IOrden Ordens { get; } 
    Task<int> SaveAsync();
}