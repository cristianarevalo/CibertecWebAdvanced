using Cibertec.Models;
using Cibertec.Repositories;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<customer> Customers { get; }
        IRepository<order> Orders { get; }
        IRepository<orderItem> OrderItems { get; }
        IRepository<product> Products { get; }
        IRepository<supplier> Suppliers { get; }
    }
}
