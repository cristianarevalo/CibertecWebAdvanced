﻿using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.Northwind.EntityFramework
{
    public class ProductRepository : RepositoryEF<product>, IProductRepository
    {
        public ProductRepository(DbContext context): base(context)
        {

        }

        public product SearchByProductName(string ProductName)
        {
            return _context.Set<product>().FirstOrDefault(x => x.ProductName == ProductName);
        }
    }
}