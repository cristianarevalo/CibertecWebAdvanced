using Cibertec.Models;
using System.Data.SqlClient;
using Dapper;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class CustomerRepository : Repository<customer>, ICustomerRepository
    {

        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public customer SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return connection.QueryFirst<customer>("dbo.SearchByNames", 
                    parameters, 
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
