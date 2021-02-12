namespace FormatLines.LineProcessors
{
	public class LineProcessingConfiguration
	{
		public LineProcessingConfiguration(string format)
		{
			Format = format;
		}

		public string Format { get; set; }

		public bool TrimLines { get; set; }

		public int? MinLineLength { get; set; }

		public bool IgnoreEmptyLines { get; set; }
	}
}
