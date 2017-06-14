using Cibertec.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class OrderItemRepository : Repository<orderItem>, IOrderItemRepository
    {
        public OrderItemRepository(string connectionString): base(connectionString)
        {

        }

        public IEnumerable<orderItem> SearchByUnitPriceGreaterEqual(decimal UnitPrice)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UnitPrice", UnitPrice);

                return connection.Query<orderItem>("dbo.SearchByUnitPriceGreaterEqual", 
                    parameters, 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
