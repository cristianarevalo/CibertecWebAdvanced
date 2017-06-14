using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository : IRepository<customer>
    {
        customer SearchByNames(string firstName, string lastName);

    }
}
