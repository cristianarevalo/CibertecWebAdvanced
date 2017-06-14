using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.Northwind.EntityFramework
{
    public class SupplierRepository : RepositoryEF<supplier>, ISupplierRepository
    {
        public SupplierRepository(DbContext context): base(context)
        {

        }

        public supplier SearchByContactName(string contactName)
        {
            return _context.Set<supplier>().FirstOrDefault(x => x.ContactName == contactName);
        }
    }
}
