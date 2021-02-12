using FormatLines.IO;
using FormatLines.LineProcessors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormatLines
{
	public class FormatLinesFlow
	{
		private readonly ILineProcessor _patcher;

		public FormatLinesFlow(LineProcessingConfiguration configuration)
		{
			_patcher = LineProcessorBuilder.Build(configuration);
		}

		public async Task RunAsync(ILineReader reader, ILineWriter writer)
		{
			await using var enumerator = GetProcessedLinesAsync(reader).GetAsyncEnumerator();

			if (!await enumerator.MoveNextAsync()) return;

			await writer.WriteAsync(enumerator.Current);

			while(await enumerator.MoveNextAsync())
			{
				await writer.AppendLineAsync(enumerator.Current);
			}
		}

		private async IAsyncEnumerable<string> GetProcessedLinesAsync(ILineReader reader)
		{
			string? line;
			while ((line = await reader.ReadLineAsync()) != null)
			{
				var processResult = _patcher.Process(line);

				if (processResult.LineAction != LineAction.Remove)
				{
					yield return processResult.Line;
				}
			}
		}
	}
}
