using System;
using System.IO;

namespace ShadowRunner.RunnerConsole
{
	/// <summary>
	/// Runs a console application and removes the temporary files.
	/// </summary>
	internal class AppDomainRunner
	{
		private readonly AppDomain _appDomain;
		private static DirectoryInfo cacheDirectory;

		/// <summary>
		/// Initializes a new instance of the <see cref="AppDomainRunner"/> class that will run
		/// the console application executable in the provided <see cref="AppDomain"/>.
		/// </summary>
		/// <param name="appDomain">The application domain containing the executable file.</param>
		public AppDomainRunner( AppDomain appDomain )
		{
			_appDomain = appDomain;
			cacheDirectory = new DirectoryInfo( _appDomain.SetupInformation.CachePath );
		}

		/// <summary>
		/// Runs the application with the specified arguments.
		/// </summary>
		/// <param name="applicationPath">The full path including filename for the application.</param>
		/// <param name="args">The arguments passed to the application.</param>
		/// <exception cref="System.ArgumentException">If the path or file does not exist.</exception>
		public void Run( string applicationPath, string[] args )
		{
			if ( !File.Exists( applicationPath ) )
			{
				throw new ArgumentException( "Could not find target application at " + applicationPath + ".", "applicationPath" );
			}

			var appName = Path.GetFileName( applicationPath );

			if ( string.IsNullOrEmpty( appName ) )
			{
				throw new ArgumentException("Path does not include a file name", applicationPath);
			}

			var appDirectory = Path.GetDirectoryName( applicationPath );

			FileSystem.CopyDirectory( new DirectoryInfo( appDirectory ), cacheDirectory );

			try
			{
				_appDomain.ExecuteAssembly(Path.Combine(cacheDirectory.FullName, appName), args);
			}
			finally
			{
				AppDomain.Unload(_appDomain);
			}
		}
	}
}