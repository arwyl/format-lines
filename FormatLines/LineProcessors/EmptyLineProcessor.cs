namespace FormatLines.LineProcessors
{
	public class EmptyLineProcessor : ILineProcessor
	{
		public LineProcessResult Process(string line)
		{
			var res = new LineProcessResult(line);

			if (string.IsNullOrEmpty(line))
			{
				res.LineAction = LineAction.Remove;
			}

			return res;
		}
	}
}
