using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.Northwind.EntityFramework
{
    public class OrderRepository : RepositoryEF<order>, IOrderRepository
    {
        public OrderRepository(DbContext context): base(context)
        {

        }

        public order SearchByOrderNumber(string orderNumber)
        {
            return _context.Set<order>().FirstOrDefault(x => x.OrderNumber == orderNumber);
        }
    }
}
