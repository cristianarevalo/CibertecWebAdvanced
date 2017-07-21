using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository: IRepository<product>
    {
        product SearchByProductName(string ProductName);
        IEnumerable<product> ListProductPaginated(int startRow, int endRow);
        int TotalRows();
    }
}
