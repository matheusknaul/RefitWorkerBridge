using System.Runtime.CompilerServices;

namespace Domain.Interfaces.Worker
{
    public interface IAppLogger<T>
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogError(string message, Exception exception, [CallerMemberName] string caller = "");

    }
}
