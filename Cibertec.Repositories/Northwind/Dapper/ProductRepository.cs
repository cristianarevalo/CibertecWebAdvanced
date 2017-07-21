using Cibertec.Models;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class ProductRepository : Repository<product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {

        }

        public int TotalRows()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(Id) FROM dbo.Product");
            }
        }

        public IEnumerable<product> ListProductPaginated(int startRow, int endRow)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);

                return connection.Query<product>("dbo.ProductPagedList",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure).AsList();
            }
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
