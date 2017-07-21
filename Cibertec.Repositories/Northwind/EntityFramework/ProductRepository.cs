using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind.EntityFramework
{
    public class ProductRepository : RepositoryEF<product>, IProductRepository
    {
        public ProductRepository(DbContext context): base(context)
        {

        }

        public IEnumerable<product> ListProductPaginated(int startRow, int endRow)
        {
            throw new NotImplementedException();
        }

        public product SearchByProductName(string ProductName)
        {
            return _context.Set<product>().FirstOrDefault(x => x.ProductName == ProductName);
        }

        public int TotalRows()
        {
            throw new NotImplementedException();
        }
    }
}
