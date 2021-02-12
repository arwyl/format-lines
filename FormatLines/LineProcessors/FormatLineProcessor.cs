namespace FormatLines.LineProcessors
{
	public class FormatLineProcessor : ILineProcessor
	{
		private readonly string _format;

		public FormatLineProcessor(string format)
		{
			_format = format;
		}

		public LineProcessResult Process(string line)
		{
			return new LineProcessResult(string.Format(_format, line));
		}
	}
}
