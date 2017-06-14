using Cibertec.Repositories.Northwind;
using Cibertec.Repositories.Northwind.Dapper;

namespace Cibertec.UnitOfWork
{
    public class CibertecUnitOfWork: IUnitOfWork
    {
        public CibertecUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);            
            Orders = new OrderRepository(connectionString);
            Products = new ProductRepository(connectionString);
            Suppliers = new SupplierRepository(connectionString);
            OrderItems = new OrderItemRepository(connectionString);            
        }

        public ICustomerRepository Customers { get; private set; }        
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }
        
    }
}
