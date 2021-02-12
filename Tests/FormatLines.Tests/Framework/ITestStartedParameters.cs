using FormatLines.LineProcessors;

namespace FormatLines.Tests.Framework
{
	public interface ITestStartedParameters
	{
		string Input { get; set; }

		string Delimiter { get; set; }

		LineProcessingConfiguration LineProcessingConfiguration { get; }
	}
}
