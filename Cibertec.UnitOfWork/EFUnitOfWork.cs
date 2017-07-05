using Cibertec.Repositories.Northwind;
using Cibertec.Repositories.Northwind.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {        
        public EFUnitOfWork(DbContext context)
        {
            //Customers = new RepositoryEF<customer>(context);
            Customers = new CustomerRepository(context);
            Orders = new OrderRepository(context);            
            Products = new ProductRepository(context);
            Suppliers = new SupplierRepository(context);
            OrderItems = new OrderItemRepository(context);
            //Users = new UserRepository(context);
            
        }

        //private set: solo puede ser modificado en esta clase
        //public IRepository<customer> Customers { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }
        public IUserRepository Users { get; private set; }

    }
}
