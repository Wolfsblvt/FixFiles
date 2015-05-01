using System;
using System.Collections.Generic;
using System.Linq;

namespace FixFiles
{
	public static class Helper
	{
		/// <summary>
		///		Validate the given parameters
		/// </summary>
		/// <param name="args">arguments from command line</param>
		/// <returns>Dictionary of arguments</returns>
		public static Dictionary<string, string> ValidateParameters(string[] args)
		{
			var dict = new Dictionary<string, string>(args.Length / 2);
			List<string> invalidArguments = new List<string>(args.Length);

			string[] allowedSingleArgs = {
				"--" + Args.HELP,
				"--" + Args.FORCE,
			};

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i].StartsWith("--") && i + 1 < args.Length && !args[i + 1].StartsWith("--"))
				{
					dict.Add(args[i].Substring(2), args[i + 1]);
					i++;
				}
				else if (args[i].StartsWith("--") && allowedSingleArgs.Contains(args[i]))
				{
					dict.Add(args[i].Substring(2), "");
				}
				else if (i == 0 && !args[i].StartsWith("--"))
				{
					dict.Add(Args.FILETYPES, args[i]);
				}
				else
				{
					invalidArguments.Add(args[i]);
				}
			}

			if (invalidArguments.Count > 0)
			{
				Console.WriteLine(Texts.WarningInvalidArgs);
				Console.WriteLine(Texts.Tab + string.Join(Environment.NewLine + Texts.Tab, invalidArguments));
			}

			return dict;
		}
	}

	public class Args
	{
		public const string HELP = "help";
		public const string FILE = "file";
		public const string FOLDER = "folder";
		public const string FILETYPES = "filetypes";
		public const string GUIDELINES = "guidelines";

		public const string FORCE = "force";
	}
}
