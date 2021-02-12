namespace FormatLines.Tests.Framework
{
	public interface ITestCompleteParameters : ITestStartedParameters
	{
		string Result { get; }
	}
}
