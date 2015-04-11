using System;
using System.IO;

namespace ShadowRunner.RunnerConsole
{
	/// <summary>
	/// Factory class for creating instaces of a <see cref="AppDomain"/> with shadow copy enabled.
	/// </summary>
	internal static class AppDomainFactory
	{
		/// <summary>
		/// Creates an <see cref="AppDomain"/> instance.
		/// </summary>
		/// <remarks>
		/// If the target console application has a configuration file it must have the same name as the executable and end in a .config extension.
		/// </remarks>
		/// <returns>An application domain which is an isolated environment where the application will execute.</returns>
		public static AppDomain Create(string appPath)
		{
			var appName = Path.GetFileNameWithoutExtension( appPath );

			if ( appName == null )
			{
				throw new ArgumentException("The specified application path does not contain a valid file name.", "appPath");
			}

			var appSetup = new AppDomainSetup
			{
				ApplicationName = appName,
				ShadowCopyFiles = "true",
				CachePath = GetTempPath(),
				ConfigurationFile = GetConfigurationFile( appPath )
			};

			return AppDomain.CreateDomain(appName, AppDomain.CurrentDomain.Evidence, appSetup);
		}

		private static string GetConfigurationFile( string appPath )
		{
			var configFile = Path.Combine(appPath + ".config");

			return File.Exists( configFile ) ? configFile : string.Empty;
		}

		private static string GetTempPath()
		{
			var currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

			if ( currentPath == null )
			{
				throw new DirectoryNotFoundException("Could not get the path for shadow copying application files.");
			}

			return Path.Combine(currentPath,  "__" + Guid.NewGuid());
		}
	}
}