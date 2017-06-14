using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository : IRepository<customer>
    {
        customer SearchByNames(string firstName, string lastName);
    }
}
