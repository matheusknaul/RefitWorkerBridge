using System.Data;

namespace Domain.Interfaces.Database
{
    public interface IConnectionFactory : IDisposable
    {

        public string ConnString { get; }

        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }
    }
}
