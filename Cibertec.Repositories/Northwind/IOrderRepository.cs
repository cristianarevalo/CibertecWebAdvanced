using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderRepository: IRepository<order>
    {
        order SearchByOrderNumber(string orderNumber);
    }
}
