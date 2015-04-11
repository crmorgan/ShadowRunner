using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using TestConsole.Logging;

namespace TestConsole
{
	/// <summary>
	/// http://stackoverflow.com/questions/1091223/log4net-across-appdomains
	/// </summary>
	class Program
	{
		private static readonly ILogger Logger;

		static Program()
		{
			Logger = new LogManager().GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
			Logger.Info( "Doing some work..." );
			var sleepTime = int.Parse( ConfigurationManager.AppSettings["TaskDurationInSeconds"] );

			Thread.Sleep( sleepTime * 1000 );
		}

		private static void LogUnhandledException( Exception e )
		{
			var errorMessage = string.Format("An unhandled exception was thrown: {0}", e.Message);

			Logger.Error(errorMessage, e);
		}

		private static void LogHeader( string[] args )
		{
			Logger.Debug("--- Begin Console Run");
			Logger.Debug("Commandline arguments: " + string.Join(",", args));
		}

		private static void LogFooter()
		{
			Logger.Debug("--- End Console Run");
		}
	}
}
