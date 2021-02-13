using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using FormatLines.IO;
using FormatLines.LineProcessors;

namespace FormatLines
{
	class Program
	{
		private static Task Main(params string[] args)
		{
			var rootCommand = new RootCommand
			{
				new Argument<string>("format", "Line format where {0} is initial line."),
				new Option<FileInfo?>(
					new [] { "--input", "-i" },
					description: "Input file to be processed. If not set stdin will be used."
				),
				new Option<string?>(
					new [] { "--delimiter", "-d" },
					"Delimiter for formatted lines. Default value is new line."
				),
				new Option<bool>(
					new [] { "--trim", "-t" },
					"If set, the input lines will be trimmed before formatting."
				),
				new Option<bool>(
					new [] { "--ignore-empty-lines", "-e" },
					"If set, empty or whitespace lines will not be formatted and included in result."
				),
				new Option<int?>(
					new [] { "--min-length", "-m" },
					"Minimum length for lines to be formatted and included in result."
				),
				new Option<FileInfo?>(
					new [] { "--output",  "-o" },
					description: "Output file name. If not set, stdout will be used."
				)
			};

			rootCommand.Handler = CommandHandler.Create(
				(
					string format,
					FileInfo? input,
					string? delimiter,
					bool trim,
					bool ignoreEmptyLines,
					int? minLength,
					FileInfo? output
				) =>
				{
					var opts = new ConsoleOptions(format, delimiter ?? Environment.NewLine)
					{
						IgnoreEmptyLines = ignoreEmptyLines,
						Input = input,
						MinLength = minLength,
						Output = output,
						Trim = trim
					};

					return RunAsync(opts);
				});

			return rootCommand.InvokeAsync(args);
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

			await using var writer = GetLineWriter(options);

			await flow.RunAsync(reader, writer);
		}

		private static ILineReader GetLineReader(ConsoleOptions options)
		{
			var innerReader = options.Input?.OpenText() ?? Console.In;
			return new LineReader(innerReader);
		}

		private static ILineWriter GetLineWriter(ConsoleOptions options)
		{
			// if user types input manually and wants to see output there also
			if(options.Input == null && options.Output == null && !Console.IsInputRedirected && !Console.IsOutputRedirected && options.Delimiter == Environment.NewLine)
			{
				return new ConsoleCorrectorWriter();
			}

			var innerWriter = options.Output?.CreateText() ?? Console.Out;

			var needsAutoFlush = options.Input == null && !Console.IsInputRedirected;

			return needsAutoFlush ? new AutoFlushLineWriter(innerWriter, options.Delimiter) : new LineWriter(innerWriter, options.Delimiter);
		}
	}
}
