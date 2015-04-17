using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FixFiles
{
	public static class ExtensionMethods
	{
		/// <summary>
		///		Get files in the directory by given extension. You can specify as many as you want
		/// </summary>
		/// <param name="dir">The directory</param>
		/// <param name="searchOption">The search option for this search</param>
		/// <param name="extensions">A list of all extensions. Can also be in one string, seperated with ','.</param>
		/// <returns></returns>
		public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, SearchOption searchOption, params string[] extensions)
		{
			if (extensions == null)
				throw new ArgumentNullException("extensions");

			string[] ext = extensions.SelectMany(s => s.Split(',')).ToArray();

			IEnumerable<FileInfo> files = dir.EnumerateFiles("*", searchOption);
			return files.Where(f => ext.Contains(f.Extension) || ext.Contains("*" + f.Extension));
		}
	}
}
