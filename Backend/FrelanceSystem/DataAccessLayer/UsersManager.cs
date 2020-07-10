using Microsoft.Extensions.Configuration;
using Serilog;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DataAccessLayer
{
    public class UsersManager : SQLConnector, IUsersManager
    {
        private readonly ILogger _logger;

        public UsersManager(IConfiguration configuration,
            ILogger logger) :
            base(configuration)
        {
            _logger = logger;
        }

        public string GetUserPassword(string email)
        {
            string getPasswordByEmailQuery = @"
                SELECT ""Password"" from Users
                WHERE Email = '{0}';
            ".Replace("{0}",email);

            string password;
            
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                _logger.Information("Connection opened.");

                password = sqlConnection.Query<string>(getPasswordByEmailQuery).FirstOrDefault();

                _logger.Information("Connection closed.");
            }

            return password;
        }
    }
}
