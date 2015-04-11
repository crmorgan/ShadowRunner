using System;

namespace ShadowRunner.RunnerConsole
{
	/// <summary>
	/// Provides methods for reading items in the command arguments array. 
	/// </summary>
	public static class ArgumentReader
	{
		public static string GetApplicationPath( string[] args )
		{
			return args[0];
		}

		public static string[] GetApplicationArgs( string[] args )
		{
			var appArgs = new string[0];

			if ( args.Length > 1 )
			{
				appArgs = new string[args.Length - 1];
				Array.Copy( args, 1, appArgs, 0, args.Length-1 );
			}

			return appArgs;
		}

		public static bool ShowUsage( string[] args )
		{
			return args.Length == 0 || args[0] == "/?" | args[0] == "help";
		}
	}
}