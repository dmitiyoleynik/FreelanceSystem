using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    abstract public class SQLConnector :IDisposable
    {
        protected readonly string _connectionString;
        protected readonly SqlConnection _sqlConnection;
        protected readonly ILogger _logger;

        public SQLConnector(IConfiguration configuration,
            ILogger logger)
        {
            _logger = logger;

            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
            _logger.Debug("Connection opened.");

        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _logger.Debug("Connection closed.");
        }
    }
}
