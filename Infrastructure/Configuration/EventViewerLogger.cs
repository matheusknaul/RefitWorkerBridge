using Domain.Interfaces.Worker;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Infrastructure.Configuration
{
    public class EventViewerLogger<T> : IAppLogger<T>
    {
        public const string SOURCE_NAME = "JsonPlaceholder Integration";
        public const string LOG_NAME = "RefitBridge";
        private readonly string _sourceName;
        private readonly string _logName;

        public EventViewerLogger()
        { 
            _sourceName = SOURCE_NAME;
            _logName = LOG_NAME;
            //Need admin permission to execute this
            if (!EventLog.SourceExists(_sourceName))
                EventLog.CreateEventSource(_sourceName, _logName);
        }

        public void LogError(string message)
        {
            EventLog.WriteEntry(_sourceName, message, EventLogEntryType.Error);
        }

        public void LogError(string message, Exception exception, [CallerMemberName] string caller = "")
        {
            var fullMessage = exception == null ? message : $"{caller}: {message}\nException: {exception}";
            EventLog.WriteEntry(_sourceName, fullMessage, EventLogEntryType.Warning);
        }

        public void LogInfo(string message)
        {
            EventLog.WriteEntry(_sourceName, message, EventLogEntryType.Information);
        }

        public void LogWarning(string message)
        {
            EventLog.WriteEntry(_sourceName, message, EventLogEntryType.Warning);
        }
    }
}
