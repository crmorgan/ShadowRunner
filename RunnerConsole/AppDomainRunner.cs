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
		private static string _tempPath;

		/// <summary>
		/// Initializes a new instance of the <see cref="AppDomainRunner"/> class that will run
		/// the console application executable in the provided <see cref="AppDomain"/>.
		/// </summary>
		/// <param name="appDomain">The application domain containing the executable file.</param>
		public AppDomainRunner(AppDomain appDomain)
		{
			_appDomain = appDomain;
			_tempPath = _appDomain.SetupInformation.CachePath;
		}

		/// <summary>
		/// Runs the application with the specified arguments.
		/// </summary>
		/// <param name="applicationPath">The full path including filename for the application.</param>
		/// <param name="args">The arguments passed to the application.</param>
		/// <exception cref="System.ArgumentException">If the path or file does not exist.</exception>
		public void Run( string applicationPath, string[] args )
		{
			if ( !File.Exists(applicationPath) )
			{
				throw new ArgumentException("Could not find target application at " + applicationPath + ".", "applicationPath");
			}

			try
			{
				_appDomain.ExecuteAssembly( applicationPath, args );
			}
			catch ( Exception )
			{
				AppDomain.Unload(_appDomain);
				AppDomain.CurrentDomain.DomainUnload += DomainUnloadedEventHandler;
				ConsoleWriter.WriteUnexpectedRunnerError();
				throw;
			}
		}

		private void DomainUnloadedEventHandler( object sender, EventArgs e )
		{
			DeleteShadowCopyDirectory();
		}


		private static void DeleteShadowCopyDirectory()
		{
			if ( Directory.Exists( _tempPath ) )
			{
				Directory.Delete( _tempPath, true );
			}
		}
	}
}