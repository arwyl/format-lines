using CommandLine;

namespace FormatLines
{
	public class ConsoleOptions
	{
		[Option('f', "format", Required = true, HelpText = "Line format where {0} is initial line.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public string Format { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		[Option('i', "input", Required = false, HelpText = "Input file to be processed. If not set stdin will be used.")]
		public string? Input { get; set; }

		[Option('d', "delimiter", Required = false, HelpText = "Delimiter for formatted lines. Default value is new line.")]
		public string? Delimiter { get; set; }

		[Option('t', "trim", Required = false, HelpText = "If set, the input lines will be trimmed before formatting.")]
		public bool Trim { get; set; }

		[Option('e', "ignore-empty-lines", Required = false, HelpText = "If set, empty or whitespace lines will not be formatted and included in result.")]
		public bool IgnoreEmptyLines { get; set; }

		[Option('m', "min-length", Required = false, HelpText = "Minimum length for lines to be formatted and included in result.")]
		public int? MinLength { get; set; }

		[Option('o', "output", Required = false, HelpText = "Output file name. If not set, stdout will be used.")]
		public string? Output { get; set; }
	}
}
