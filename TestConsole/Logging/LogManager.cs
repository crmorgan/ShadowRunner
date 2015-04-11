using System;
using System.IO;

namespace TestConsole.Logging
{
	public class LogManager : ILogManager
	{
		static LogManager()
		{
			var basePath = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location );

			var filePath = Path.Combine(basePath, "log4net.config");
			var fileInfo = new FileInfo(filePath);

			if (fileInfo.Exists)
			{
				log4net.Config.XmlConfigurator.ConfigureAndWatch(fileInfo);
			}
			else
			{
				throw new FileNotFoundException("Could not find the log4net configuration file at " + filePath, filePath);
			}
		}

		public ILogger GetLogger(Type type)
		{
			var logger = log4net.LogManager.GetLogger(type);
			return new LoggingAdapter(logger);
		}

		public ILogger GetLogger(string name)
		{
			var logger = log4net.LogManager.GetLogger(name);
			return new LoggingAdapter(logger);
		}
	}
}
