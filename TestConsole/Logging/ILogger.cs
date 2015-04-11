using System;

namespace TestConsole.Logging
{
    public interface ILogger
    {
        void Debug(object message, Exception ex = null);
        void Info(object message, Exception ex = null);
        void Warn(object message, Exception ex = null);
        void Error(object message, Exception ex = null);
        void Fatal(object message, Exception ex = null);
        void Alert(object message, Exception ex = null);
    }
}
