using System;

namespace FormatLines.Tests.Framework
{
	public static class ArrangeExtensions
	{
		public static IArrangeParameters WithDelimiter(this IArrangeParameters pars, string delimiter)
		{
			pars.Delimiter = delimiter;
			return pars;
		}

		public static IArrangeParameters WithInput(this IArrangeParameters pars, string input)
		{
			pars.Input = input;
			return pars;
		}

		public static IArrangeParameters WithInput(this IArrangeParameters pars, params string[] lines)
		{
			pars.Input = string.Join(Environment.NewLine, lines);
			return pars;
		}

		public static IArrangeParameters WithFormat(this IArrangeParameters pars, string format)
		{
			pars.LineProcessingConfiguration.Format = format;
			return pars;
		}

		public static IArrangeParameters WithTrimLines(this IArrangeParameters pars)
		{
			pars.LineProcessingConfiguration.TrimLines = true;
			return pars;
		}

		public static IArrangeParameters WithIgnoreEmptyLines(this IArrangeParameters pars)
		{
			pars.LineProcessingConfiguration.IgnoreEmptyLines = true;
			return pars;
		}

		public static IArrangeParameters WithMinLineLength(this IArrangeParameters pars, int minLength)
		{
			pars.LineProcessingConfiguration.MinLineLength = minLength;
			return pars;
		}
	}
}
