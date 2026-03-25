using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace ApiProduct.Shared.Configuration.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        #region [Properties]

        private readonly IConfiguration _configuration;
        private readonly ILogger<ConnectionFactory> _logger;

        #endregion

        #region [Constructor]

        public ConnectionFactory(IConfiguration configuration, ILogger<ConnectionFactory> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        #endregion

        #region [Interfaces]

        public IDbConnection GetConnectionProduct
        {
            get { return CreateConnection(_configuration["DataBaseConnection:SQLServer:DB_Login"]); }
        }

        #endregion

        #region [Methods]

        public IDbConnection CreateConnection(string pDataBase)
        {
            if (string.IsNullOrEmpty(pDataBase))
            {
                _logger.LogError("Conexion no encontrada");
                throw new Exception("Conexion no encontrada");
            }

            var connection = new SqlConnection();
            connection.ConnectionString = pDataBase;
            connection.Open();

            return connection;
        }

        #endregion
    }
}
