using Cibertec.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class ProductRepository : Repository<product>, IProductRepository
    {
        public ProductRepository(string connectionString): base(connectionString)
        {

        }

        public product SearchByProductName(string ProductName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductName", ProductName);

                return connection.QueryFirst<product>("dbo.SearchByProductName", 
                    parameters, 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
