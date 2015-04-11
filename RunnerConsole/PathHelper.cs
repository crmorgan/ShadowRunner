using System;
using System.Configuration;
using System.IO;

namespace ShadowRunner.RunnerConsole
{
	internal static class PathHelper
	{
		public static string GetExecutablePath()
		{
			return Path.Combine(GetRootPath(), GetApplicationName() + ".exe");
		}

		public static string GetConfigurationFilePath()
		{
			return Path.Combine(GetExecutablePath() + ".config");
		}

		

		public static string GetApplicationName()
		{
			return ConfigurationManager.AppSettings["TargetApplicationFileName"];
		}

		private static string GetRootPath()
		{
			return Path.GetDirectoryName(ConfigurationManager.AppSettings["TargetApplicationRootPath"]);
		}
	}
}