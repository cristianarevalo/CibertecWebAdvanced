using Cibertec.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class OrderRepository : Repository<order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }
        public order SearchByOrderNumber(string orderNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@orderNumber", orderNumber);

                return connection.QueryFirst<order>("dbo.SearchByOrderNumber", 
                    parameters, 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
