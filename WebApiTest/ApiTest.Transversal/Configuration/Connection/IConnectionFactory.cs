using System.Data;

namespace ApiProduct.Shared.Configuration.Connection
{
    public interface IConnectionFactory
    {
        public IDbConnection GetConnectionProduct { get; }
    }
}
