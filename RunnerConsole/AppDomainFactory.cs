using System;
using System.IO;

namespace ShadowRunner.RunnerConsole
{
	/// <summary>
	/// Simple factory class for creating instaces of a <see cref="AppDomain"/>.
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
		public static AppDomain Create(string appPath, string cachePath)
		{
			var appName = Path.GetFileNameWithoutExtension( appPath );

			if ( appName == null )
			{
				throw new ArgumentException("The specified application path does not contain a valid file name.", "appPath");
			}

			var appSetup = new AppDomainSetup
			{
				ApplicationName = appName,
				CachePath = cachePath,
				ConfigurationFile = string.Empty
			};

			return AppDomain.CreateDomain(appName, AppDomain.CurrentDomain.Evidence, appSetup);
		}
	}
}