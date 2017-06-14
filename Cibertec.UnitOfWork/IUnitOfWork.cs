using Cibertec.Repositories.Northwind;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        IOrderItemRepository OrderItems { get; }
        
    }
}
