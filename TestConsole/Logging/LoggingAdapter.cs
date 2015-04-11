using System;
using log4net;

namespace TestConsole.Logging
{
    public class LoggingAdapter : ILogger
    {
        private readonly ILog _log;

        public LoggingAdapter(ILog log)
        {
            _log = log;
        }

        public void Debug(object message, Exception ex = null)
        {
            _log.Debug(message, ex);
        }

        public void Info(object message, Exception ex = null)
        {
            _log.Info(message, ex);
        }

        public void Warn(object message, Exception ex = null)
        {
            _log.Warn(message, ex);
        }

        public void Error(object message, Exception ex = null)
        {
            _log.Error(message, ex);
        }

        public void Fatal(object message, Exception ex = null)
        {
            _log.Fatal(message, ex);
        }

        public void Alert(object message, Exception ex = null)
        {
            //This is a sample method that we can use to send specific alerts to Inspirato from the system
            //We shouldn't rely on log4net to send these messages as it is not a reliable logging framework
            //From here we could send an email, log the message, etc...
        }
    }
}
