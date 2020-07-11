using Microsoft.Extensions.Configuration;
using Serilog;
using Dapper;
using System.Linq;

namespace DataAccessLayer
{
    public class UsersManager : SQLConnector, IUsersManager
    {
        public UsersManager(IConfiguration configuration,
            ILogger logger) :
            base(configuration, logger)
        {
        }

        public string GetUserPassword(string email)
        {
            string getPasswordByEmailQuery = @"
                SELECT ""Password"" from Users
                WHERE Email = '{0}';
            ".Replace("{0}", email);

            string password = _sqlConnection.Query<string>(getPasswordByEmailQuery).FirstOrDefault();

            return password;
        }
    }
}
