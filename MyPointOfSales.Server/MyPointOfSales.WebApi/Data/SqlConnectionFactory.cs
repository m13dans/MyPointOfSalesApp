using System.Data;
using Microsoft.Data.SqlClient;

namespace PointOfSalesApp.API.Data;

public class SqlConnectionFactory(IConfiguration config)
{
    public IDbConnection CreateSqlConnection() =>
        new SqlConnection(config.GetConnectionString("SqlConnection"));
}
