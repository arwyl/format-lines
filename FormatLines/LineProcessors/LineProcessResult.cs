namespace FormatLines.LineProcessors
{
	public class LineProcessResult
	{
		public LineProcessResult(string line)
		{
			Line = line;
		}

		public string Line { get; init; }

		public LineAction LineAction { get; set; } = LineAction.None;
	}
}
