using System.Collections.Generic;

namespace FormatLines.LineProcessors
{
	public class LineProcessorsCollection : ILineProcessor
	{
		private readonly IReadOnlyList<ILineProcessor> _processors;

		public LineProcessorsCollection(IReadOnlyList<ILineProcessor> processors)
		{
			_processors = processors;
		}

		public LineProcessResult Process(string line)
		{
			var res = new LineProcessResult(line);

			foreach(var processor in _processors)
			{
				res = processor.Process(res.Line);

				if (!IsContinueAction(res.LineAction))
				{
					return res;
				}
			}

			return res;
		}

		private static bool IsContinueAction(LineAction action)
		{
			return action == LineAction.None;
		}
	}
}
