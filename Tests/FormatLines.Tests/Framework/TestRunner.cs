using FormatLines.LineProcessors;
using FormatLines.Tests.Infrastructure;
using System;
using System.Threading.Tasks;

namespace FormatLines.Tests.Framework
{
	public class TestRunner
	{
		public async Task RunAsync(Action<IArrangeParameters> arrange, Action<IAssertParameters> assert)
		{
			var pars = new TestParameters();

			arrange.Invoke(pars);

			using var reader = new StringLineReader(pars.Input);

			await using var writer = new StringLineWriter(pars.Delimiter);

			var flow = new FormatLinesFlow(pars.LineProcessingConfiguration);

			await flow.RunAsync(reader, writer);

			pars.Result = await writer.GetResultAsync();

			assert.Invoke(pars);
		}

		private class TestParameters : IAssertParameters, IArrangeParameters
		{
			public string Result { get; set; } = string.Empty;

			public string Input { get; set; } = string.Empty;

			public string Delimiter { get; set; } = Environment.NewLine;

			public LineProcessingConfiguration LineProcessingConfiguration { get; } = new LineProcessingConfiguration("{0}");
		}
	}
}
