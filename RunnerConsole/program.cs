using System;

namespace ShadowRunner.RunnerConsole
{
	/// <summary>
	/// Runs a console applications in a shadow copy mode allowing the target application to be updatable when running.
	/// http://www.codeproject.com/Articles/29961/Shadow-Copying-of-Applications
	/// </summary>
	class Program
	{
		[LoaderOptimization(LoaderOptimization.MultiDomainHost)]
		[STAThread]
		public static void Main( string[] args )
		{
			args = new[] { @"D:\SVNProjects\Inspirato\tools\ShadowRunner\TestConsole\bin\TestConsole.exe", "DoSomething" };

			ConsoleWriter.WriteBanner();
			
			if ( ArgumentReader.ShowUsage(args) )
			{
				ConsoleWriter.WriteUsage();
			}
			else
			{
				RunApplication(args);
			}
		}

		private static void RunApplication( string[] args )
		{
			var appPath = ArgumentReader.GetApplicationPath( args );
			var appDomain = AppDomainFactory.Create( appPath );
			var runner = new AppDomainRunner( appDomain );

			ConsoleWriter.WriteRunStarting( appDomain );

			runner.Run( appPath, ArgumentReader.GetApplicationArgs( args ) );

			ConsoleWriter.WriteRunComplete();
		}
	}
}