using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class SQLConnector
    {
        protected readonly string _connectionString;

        public SQLConnector(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
