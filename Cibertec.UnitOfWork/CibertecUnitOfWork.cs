using Cibertec.Models;
using Cibertec.Repositories;
using Cibertec.Repositories.Northwind;
using Cibertec.Repositories.Northwind.Dapper;

namespace Cibertec.UnitOfWork
{
    public class CibertecUnitOfWork: IUnitOfWork
    {
        public CibertecUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
            Products = new Repository<product>(connectionString);
            Orders = new Repository<order>(connectionString);
            OrderItems = new Repository<orderItem>(connectionString);
            Suppliers = new Repository<supplier>(connectionString);
        }

        public ICustomerRepository Customers { get; private set; }
        public IRepository<product> Products { get; private set; }
        public IRepository<order> Orders { get; private set; }
        public IRepository<orderItem> OrderItems { get; private set; }
        public IRepository<supplier> Suppliers { get; private set; }
    }
}
