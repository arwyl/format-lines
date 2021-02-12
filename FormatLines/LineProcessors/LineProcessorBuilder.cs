using System.Collections.Generic;

namespace FormatLines.LineProcessors
{
	public class LineProcessorBuilder
	{
		public static ILineProcessor Build(LineProcessingConfiguration config)
		{
			var processors = new List<ILineProcessor>();

			if(config.TrimLines)
			{
				processors.Add(new TrimLineProcessor());
			}

			if (config.IgnoreEmptyLines)
			{
				processors.Add(new EmptyLineProcessor());
			}

			if (config.MinLineLength.HasValue)
			{
				processors.Add(new MinLengthLineProcessor(config.MinLineLength.Value));
			}

			processors.Add(new FormatLineProcessor(config.Format));

			return new LineProcessorsCollection(processors);
		}
	}
}
