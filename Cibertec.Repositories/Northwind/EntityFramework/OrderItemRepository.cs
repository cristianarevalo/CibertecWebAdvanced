using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cibertec.Repositories.Northwind.EntityFramework
{
    public class OrderItemRepository : RepositoryEF<orderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContext context): base(context)
        {

        }

        public IEnumerable<orderItem> SearchByUnitPriceGreaterEqual(decimal UnitPrice)
        {
            return _context.Set<orderItem>().Where(x => x.UnitPrice >= UnitPrice);
        }
    }
}
