using Cibertec.Models;
using Cibertec.Repositories;
using Cibertec.Repositories.Northwind;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IRepository<order> Orders { get; }
        IRepository<orderItem> OrderItems { get; }
        IRepository<product> Products { get; }
        IRepository<supplier> Suppliers { get; }
    }
}
