using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SkelettonContext _context;
    private IRol _roles;
    private IUser _users;
    private IUserRol _userole;
    private IAmount _amounts;
    private IAmountDetail _amountDetails;
    private ICity _cities;
    private IPersonType _personTypes;
    private IClient _clients;
    private IColor _colors;
    private ICompany _companies;
    private ICountry _countries;
    private IDetailOrder _detailOrders;
    private IDress _dresses;
    private IDressInput _dressInputs;
    private IEmployee _employees;
    private IGender _genders;
    private IPaymentMethod _paymentMethods;
    private IPosition _positions;
    private IProtectionType _protectionTypes;
    private ISize _sizes;
    private IState _states;
    private IStatus _statuses;
    private IStatusType _statusTypes;
    private ISupplier _suppliers;
    private ISupplierInput _supplierInputs;
    public UnitOfWork(SkelettonContext context)
    {
        _context = context;
    }
    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }
    public IUserRol UserRoles
    {
        get
        {
            if (_userole == null)
            {
                _userole = new UseRolRepository(_context);
            }
            return _userole;
        }
    }
    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    public IAmount Amounts
    {
        get
        {
            if (_amounts == null)
            {
                _amounts = new AmountRepository(_context);
            }
            return _amounts;
        }
    }
    public IAmountDetail AmountDetails
    {
        get
        {
            if (_amountDetails == null)
            {
                _amountDetails = new AmountDetailRepository(_context);
            }
            return _amountDetails;
        }
    }
    public ICity Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepository(_context);
            }
            return _cities;
        }
    }
    public IPersonType PersonTypes
    {
        get
        {
            if (_personTypes == null)
            {
                _personTypes = new PersonTypeRepository(_context);
            }
            return _personTypes;
        }
    }
    public IClient Clients
    {
        get
        {
            if (_clients == null)
            {
                _clients = new ClientRepository(_context);
            }
            return _clients;
        }
    }
    public IColor Colors
    {
        get
        {
            if (_colors == null)
            {
                _colors = new ColorRepository(_context);
            }
            return _colors;
        }
    }
    public ICompany Companies
    {
        get
        {
            if (_companies == null)
            {
                _companies = new CompanyRepository(_context);
            }
            return _companies;
        }
    }
    public ICountry Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepository(_context);
            }
            return _countries;
        }
    }
    public IDetailOrder DetailOrders
    {
        get
        {
            if (_detailOrders == null)
            {
                _detailOrders = new DetailOrderRepository(_context);
            }
            return _detailOrders;
        }
    }
    public IDress Dresses
    {
        get
        {
            if (_dresses == null)
            {
                _dresses = new DressRepository(_context);
            }
            return _dresses;
        }
    }
    public IDressInput DressInputs
    {
        get
        {
            if (_dressInputs == null)
            {
                _dressInputs = new DressInputRepository(_context);
            }
            return _dressInputs;
        }
    }
    public IEmployee Employees
    {
        get
        {
            if (_employees == null)
            {
                _employees = new EmployeeRepository(_context);
            }
            return _employees;
        }
    }
    public IGender Genders
    {
        get
        {
            if (_genders == null)
            {
                _genders = new GenderRepository(_context);
            }
            return _genders;
        }
    }
    public IPaymentMethod PaymentMethods
    {
        get
        {
            if (_paymentMethods == null)
            {
                _paymentMethods = new PaymentMethodRepository(_context);
            }
            return _paymentMethods;
        }
    }
    public IPosition Positions
    {
        get
        {
            if (_positions == null)
            {
                _positions = new PositionRepository(_context);
            }
            return _positions;
        }
    }
    public IProtectionType ProtectionTypes
    {
        get
        {
            if (_protectionTypes == null)
            {
                _protectionTypes = new ProtectionTypeRepository(_context);
            }
            return _protectionTypes;
        }
    }
    public ISize Sizes
    {
        get
        {
            if (_sizes == null)
            {
                _sizes = new SizeRepository(_context);
            }
            return _sizes;
        }
    }
    public IState States
    {
        get
        {
            if (_states == null)
            {
                _states = new StateRepository(_context);
            }
            return _states;
        }
    }
    public IStatus Statuses
    {
        get
        {
            if (_statuses == null)
            {
                _statuses = new StatusRepository(_context);
            }
            return _statuses;
        }
    }
    public IStatusType StatusTypes
    {
        get
        {
            if (_statusTypes == null)
            {
                _statusTypes = new StatusTypeRepository(_context);
            }
            return _statusTypes;
        }
    }
    public ISupplier Suppliers
    {
        get
        {
            if (_suppliers == null)
            {
                _suppliers = new SupplierRepository(_context);
            }
            return _suppliers;
        }
    }
    public ISupplierInput SupplierInputs
    {
        get
        {
            if (_supplierInputs == null)
            {
                _supplierInputs = new SupplierInputRepository(_context);
            }
            return _supplierInputs;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}