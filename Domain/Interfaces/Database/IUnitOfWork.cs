using System.Data;

namespace Domain.Interfaces.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Begin(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
    }
}
