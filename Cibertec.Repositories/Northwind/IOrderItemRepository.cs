using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderItemRepository: IRepository<orderItem>
    {
        IEnumerable<orderItem> SearchByUnitPriceGreaterEqual(decimal UnitPrice);
    }
}
