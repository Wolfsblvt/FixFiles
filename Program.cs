using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FixFiles
{
	class Program
	{
		static void Main(string[] arguments)
		{
			string defaultTypes = "*.php,*.html,*.yml,*.txt,*.js,*.json";


			var args = Helper.ValidateParameters(arguments);

			// Write Title :P
			Console.WriteLine(Texts.Title);

			if (args.ContainsKey(Args.FOLDER))
			{
				Environment.CurrentDirectory = args[Args.FOLDER];
			}

			Console.WriteLine(Texts.InfoCurrentFolder, Environment.CurrentDirectory);

			// If help, we display help
			if (args.ContainsKey(Args.HELP))
			{
				Console.WriteLine(Texts.Helpline);
				exit();
			}

			try
			{
				string folder = string.Empty;
				string types = string.Empty;
				string codingGuidelines = string.Empty;

				if (!args.ContainsKey(Args.FORCE))
				{
					if (!args.ContainsKey(Args.FOLDER))
					{
						Console.Write(Texts.QuestionFolder);
						folder = Console.ReadLine(); 
					}

					if (args.ContainsKey(Args.FILETYPES))
					{
						types = args[Args.FILETYPES];
					}
					else
					{
						Console.Write(Texts.QuestionFileTypes, defaultTypes);
						types = Console.ReadLine();
					}

					if (args.ContainsKey(Args.GUIDELINES))
					{
						codingGuidelines = args[Args.GUIDELINES];
					}
					else
					{
						Console.Write(Texts.QuestionCodingGuidelines);
						codingGuidelines = Console.ReadLine(); 
					}

					Console.WriteLine(); 
				}


				// Setting up used vars
				types = (types == string.Empty) ? defaultTypes : types;
				var utf8WithoutBOM = new System.Text.UTF8Encoding(false);
				bool shouldCodingGuidelines = (!string.Equals(codingGuidelines, "no"));

				int count = 0, unmodified = 0;

				var files = new DirectoryInfo(Environment.CurrentDirectory).GetFilesByExtensions(SearchOption.AllDirectories, types);

				foreach (var f in files)
				{
					if (f.DirectoryName.ToString().Contains(@"\vendor") || f.DirectoryName.ToString().Contains(@"\lib"))
						continue;

					// We can't modify this file ;) so skip it
					if (f.FullName == System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
						continue;

					string originalFile = File.ReadAllText(f.FullName);

					// replace line feeds with unix line feeds
					string s = originalFile.Replace("\r\n", "\n");

					// Do Coding guideline things
					if (shouldCodingGuidelines)
					{
						// Replace whitespaces and tabs at empty lines
						s = Regex.Replace(s, @"\n\s+\n", "\n\n");

						// Replace whitespaces at the end of lines
						s = Regex.Replace(s, @"[ \t]+\n", "\n");

						if (f.Extension.Contains("yml"))
						{
							// Replace tabs with four spaces for yml files
							s = Regex.Replace(s, @"\t", "    ");
						}
						else
						{
							// Replace two to four whitespaces with tabs for all other files
							s = Regex.Replace(s, @" {2,4}", "\t");
						}
					}

					File.WriteAllText(f.FullName, s, utf8WithoutBOM);

					// Check if nothing has changed
					if (string.Equals(originalFile, s))
					{
						unmodified++;
					}
					else
					{
						count++;
						Console.WriteLine(Texts.SavedFile, f.FullName);
					}
				}

				// End output
				Console.WriteLine(Texts.FinishLine, count, unmodified);
				exit();
			}
			catch (Exception e)
			{
				Console.WriteLine(Texts.ErrorMessage, e.Message);
				Console.WriteLine();
				Console.WriteLine(e.StackTrace);
				exit();
			}
		}
		private static void exit()
		{
#if DEBUG
			Console.Read();
#endif
			Environment.Exit(0);
		}
	}
}
