using System;
using System.Reflection;

namespace ShadowRunner.RunnerConsole
{
	internal static class ConsoleWriter
	{
		public static void WriteBanner()
		{
			Console.WriteLine(@"   _____ __              __                 ____                             ");
			Console.WriteLine(@"  / ___// /_  ____ _____/ /___ _      __   / __ \__  ______  ____  ___  _____");
			Console.WriteLine(@"  \__ \/ __ \/ __ `/ __  / __ \ | /| / /  / /_/ / / / / __ \/ __ \/ _ \/ ___/");
			Console.WriteLine(@" ___/ / / / / /_/ / /_/ / /_/ / |/ |/ /  / _, _/ /_/ / / / / / / /  __/ /    ");
			Console.WriteLine(@"/____/_/ /_/\__,_/\__,_/\____/|__/|__/  /_/ |_|\__,_/_/ /_/_/ /_/\___/_/     ");
			Console.WriteLine();
			Console.WriteLine("Version v{0}", Assembly.GetEntryAssembly().GetName().Version);
			Console.WriteLine();
		}

		public static void WriteUsage()
		{
			Console.WriteLine("Runs a console application in a shadow copy mode so it is updatable while running.");
			Console.WriteLine();
			Console.WriteLine("SHADOWRUNNER application [arguments]");
			Console.WriteLine();
			Console.WriteLine(@"  application    Specifies the full path and filename of the console application to run.");
			Console.WriteLine(@"  arguments      The arguments that are passed to the target console application.");
			Console.WriteLine();
			Console.WriteLine(@"Example: shadowrunner C:\MyConsole\MyConsole.exe someargument" );
			Console.WriteLine();

		}

		public static void WriteRunStarting( AppDomain appDomain )
		{
			Console.WriteLine("Running the {0} application", appDomain.FriendlyName);
			Console.WriteLine();
		}

		public static void WriteRunComplete()
		{
			Console.WriteLine();
			Console.WriteLine("Shadow Run completed");
			Console.WriteLine();
		}
	}
}