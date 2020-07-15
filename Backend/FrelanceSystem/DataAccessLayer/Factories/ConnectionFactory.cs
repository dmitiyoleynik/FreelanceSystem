using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace BussinessLayer.Factories
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;

        public ConnectionFactory(IConfiguration configuration, 
            ILogger logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IDbConnection CreateConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            _logger.Debug("Connection opened.");

            return sqlConnection;
        }
    }
}
