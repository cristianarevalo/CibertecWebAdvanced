using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface ISupplierRepository: IRepository<supplier>
    {
        supplier SearchByContactName(string contactName);
    }
}
