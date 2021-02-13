using System.IO;

namespace FormatLines
{
	public class ConsoleOptions
	{
		public ConsoleOptions(string format, string delimiter)
		{
			Format = format;
			Delimiter = delimiter;
		}

		public string Format { get; set; }

		public FileInfo? Input { get; set; }

		public string Delimiter { get; set; }

		public bool Trim { get; set; }

		public bool IgnoreEmptyLines { get; set; }

		public int? MinLength { get; set; }

		public FileInfo? Output { get; set; }
	}
}
