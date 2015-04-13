using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using TestConsole.Logging;


namespace TestConsole
{
	/// <summary>
	/// Simple console app that writes to the console using log4net.
	/// </summary>
	class Program
	{
		private static readonly ILogger logger;

		static Program()
		{
			logger = new LogManager().GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		}

		static void Main( string[] args )
		{
			try
			{
				LogHeader(args);
				DoSomething();
			}
			catch ( Exception e )
			{
				LogUnhandledException(e);
			}
			finally
			{
				LogFooter();
			}
		}

		private static void DoSomething()
		{
			logger.Info( "Doing some work..." );
			var sleepTime = int.Parse( ConfigurationManager.AppSettings["TaskDurationInSeconds"] );

			Thread.Sleep( sleepTime * 1000 );
		}

		private static void LogUnhandledException( Exception e )
		{
			var errorMessage = string.Format("An unhandled exception was thrown: {0}", e.Message);

			logger.Error(errorMessage, e);
		}

		private static void LogHeader( string[] args )
		{
			logger.Debug("Begin Task");
			logger.Debug("Commandline arguments: " + string.Join(",", args));
		}

		private static void LogFooter()
		{
			logger.Debug("End Task");
		}
	}
}
