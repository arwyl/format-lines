using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using FormatLines.IO;
using FormatLines.LineProcessors;

namespace FormatLines
{
	class Program
	{
		private static async Task Main(params string[] args)
		{
			await Parser.Default.ParseArguments<ConsoleOptions>(args).WithParsedAsync(RunAsync);
		}

		private static async Task RunAsync(ConsoleOptions options)
		{
			var config = new LineProcessingConfiguration(options.Format)
			{
				MinLineLength = options.MinLength,
				IgnoreEmptyLines = options.IgnoreEmptyLines,
				TrimLines = options.Trim
			};

			var flow = new FormatLinesFlow(config);

			using var reader = GetLineReader(options);

			await using var writer = GetLineWriter(options, options.Delimiter ?? Environment.NewLine);

			await flow.RunAsync(reader, writer);
		}

		private static ILineReader GetLineReader(ConsoleOptions options)
		{
			var innerReader = string.IsNullOrEmpty(options.Input) ? Console.In : File.OpenText(options.Input);
			return new LineReader(innerReader);
		}

		private static ILineWriter GetLineWriter(ConsoleOptions options, string delimiter)
		{
			var innerWriter = string.IsNullOrEmpty(options.Output) ? Console.Out : new StreamWriter(options.Output, false, Encoding.UTF8);

			var isManualInput = string.IsNullOrEmpty(options.Input) && !Console.IsInputRedirected;

			return isManualInput ? new AutoFlushLineWriter(innerWriter, delimiter) : new LineWriter(innerWriter, delimiter);
		}
	}
}
