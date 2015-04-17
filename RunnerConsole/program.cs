using System;
using System.IO;

namespace ShadowRunner.RunnerConsole
{
	class Program
	{
		private static string cachePath;

		static Program()
		{
			SetCachePath();
			AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler;
		}

		[LoaderOptimization(LoaderOptimization.MultiDomainHost)]
		public static void Main( string[] args )
		{
			//args = new[] { @"C:\Repos\ShadowRunner\TestConsole\bin\TestConsole.exe", "DoSomething" };

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
			var appDomain = AppDomainFactory.Create(appPath, cachePath);
			var runner = new AppDomainRunner( appDomain );

			ConsoleWriter.WriteRunStarting( appDomain );

			try
			{
				runner.Run( appPath, ArgumentReader.GetApplicationArgs( args ) );
			}
			catch ( Exception e)
			{
				Console.WriteLine( "An error occured in the target application: {0}", e.Message	 );
			}

			ConsoleWriter.WriteRunComplete();
		}

		private static void ProcessExitHandler( object sender, EventArgs e )
		{
			if ( !string.IsNullOrEmpty(cachePath) && Directory.Exists(cachePath) )
			{
				Console.WriteLine("Deleting cache directory");
				Directory.Delete(cachePath, true);
			}
		}

		private static void SetCachePath()
		{
			var currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

			if ( currentPath == null )
			{
				throw new DirectoryNotFoundException();
			}

			cachePath = Path.Combine(currentPath, "__" + Guid.NewGuid());
		}
	}
}