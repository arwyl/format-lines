namespace FormatLines.LineProcessors
{
	public interface ILineProcessor
	{
		LineProcessResult Process(string line);
	}
}
