using System;
using System.IO;

namespace ShadowRunner.RunnerConsole
{
	public static class FileSystem
	{
		/// <summary>
		/// Copies the specified directory and its subdirectories.
		/// </summary>
		/// <param name="source">The source directory.</param>
		/// <param name="target">The target directory.</param>
		public static void CopyDirectory( DirectoryInfo source, DirectoryInfo target )
		{
			if ( String.Equals( source.FullName, target.FullName, StringComparison.CurrentCultureIgnoreCase ) )
			{
				return;
			}

			if ( !Directory.Exists( target.FullName ) )
			{
				Directory.CreateDirectory( target.FullName );
			}

			foreach ( var file in source.GetFiles() )
			{
				file.CopyTo( Path.Combine( target.ToString(), file.Name ), true );
			}

			foreach ( var directory in source.GetDirectories() )
			{
				var nextTargetSubDir = target.CreateSubdirectory( directory.Name );
				CopyDirectory( directory, nextTargetSubDir );
			}
		}
	}
}