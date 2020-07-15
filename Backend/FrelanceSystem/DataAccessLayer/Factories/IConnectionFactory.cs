using System.Data;

namespace BussinessLayer.Factories
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
