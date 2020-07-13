using Microsoft.Extensions.Configuration;
using Serilog;
using Dapper;
using System.Linq;
using BussinessLayer.Factories;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class UsersManager : IUsersManager
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsersManager(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public User GetUser(string email)
        {
            string getUserQuery = @"
                SELECT * from Users
                WHERE Email = '{0}';
            ".Replace("{0}", email);

            User user;

            using (var _sqlConnection = _connectionFactory.CreateConnection())
            {
                user = _sqlConnection.Query<User>(getUserQuery).FirstOrDefault();
            }

            return user;
        }
    }
}
