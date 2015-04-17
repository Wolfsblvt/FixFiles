using System;

namespace FixFiles
{
	class Texts
	{
		public static string Title =
			  "FixFiles by Wolfsblvt" + Environment.NewLine
			+ "=====================" + Environment.NewLine;
		public static string Tab = "\t";

		public static string WarningInvalidArgs = "WARNING: Invalid arguments entered.";
		public static string ErrorMessage = "Error occured: {0}";

		public static string InfoCurrentFolder = "Current folder is: {0}" + Environment.NewLine;

		public static string QuestionFolder = "Just one folder? Specify the chosen folder (if empty all files from all folders from current folder): ";
		public static string QuestionFileTypes = "Specify file types (if none, \"{0}\" is chosen): ";
		public static string QuestionCodingGuidelines = "Match coding guidelines? type \"no\" if no, all other means yes: ";

		public static string SavedFile = "Saved file: {0}";

		public static string FinishLine = "===========================" + Environment.NewLine
			+ "Finished. Changed {0} files. Left {1} unmodified.";

		public static string Helpline =
			  "Following Parameters are allowed:" + Environment.NewLine
			+ Texts.Tab + "--help" + Texts.Tab + "Displays this help" + Environment.NewLine
			+ Texts.Tab + "--dir ____" + Texts.Tab + "Specify the path to the directory of phpBB" + Environment.NewLine
			+ Texts.Tab + "--file ____" + Texts.Tab + "Specify the filename wich should be used as config" + Environment.NewLine
			+ Texts.Tab + "--force" + Texts.Tab + "Force execution without interruption" + Environment.NewLine
			+ Texts.Tab + "--show" + Texts.Tab + "Shows the current used config" + Environment.NewLine;
	}
}
