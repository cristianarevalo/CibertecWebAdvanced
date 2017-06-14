using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.Northwind.EntityFramework
{
    public class CustomerRepository : RepositoryEF<customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context): base(context)
        {

        }

        public customer SearchByNames(string firstName, string lastName)
        {
            return _context.Set<customer>().FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }
    }
}
