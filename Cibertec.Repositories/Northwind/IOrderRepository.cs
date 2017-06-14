using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderRepository: IRepository<order>
    {
        order SearchByOrderNumber(string orderNumber);
    }
}
