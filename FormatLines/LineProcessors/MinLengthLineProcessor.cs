using System;

namespace FormatLines.LineProcessors
{
	public class MinLengthLineProcessor : ILineProcessor
	{
		private readonly int _minLength;

		public MinLengthLineProcessor(int minLength)
		{
			if (minLength < 1) throw new ArgumentException("Value must be greater than zero", nameof(minLength));

			_minLength = minLength;
		}

		public LineProcessResult Process(string line)
		{
			var res = new LineProcessResult(line);

			if (line.Length < _minLength)
			{
				res.LineAction = LineAction.Remove;
			}

			return res;
		}
	}
}
