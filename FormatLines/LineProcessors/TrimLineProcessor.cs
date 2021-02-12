namespace FormatLines.LineProcessors
{
	public class TrimLineProcessor : ILineProcessor
	{
		public LineProcessResult Process(string line)
		{
			return new LineProcessResult(line.Trim());
		}
	}
}
