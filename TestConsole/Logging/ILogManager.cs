using System;

namespace TestConsole.Logging
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
        ILogger GetLogger(String name);
    }
}
