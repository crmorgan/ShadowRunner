using System;
using System.Reflection;

namespace ShadowRunner.RunnerConsole
{
	internal static class ConsoleWriter
	{
		public static void WriteBanner()
		{
			var version = Assembly.GetEntryAssembly().GetName().Version;

			Console.WriteLine( "Shadow Runner v{0}", version );
			Console.WriteLine();
		}

		public static void WriteUsage()
		{
			Console.WriteLine("Runs a console application in a shadow copy mode so it is updatable while running.");
			Console.WriteLine();
			Console.WriteLine("SHADOWRUNNER application [arguments]");
			Console.WriteLine();
			Console.WriteLine("  application    Specifies the full path and filename of the console application to run.");
			Console.WriteLine("  arguments      The arguments that are passed to the target console application.");
		}

		public static void WriteRunStarting(AppDomain appDomain)
		{
			Console.WriteLine("Running the {0} application", appDomain.FriendlyName);
			Console.WriteLine();
		}

		public static void WriteRunComplete( )
		{
			Console.WriteLine("Run completed");
			Console.WriteLine();
		}
	}
}