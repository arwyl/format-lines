using FormatLines.IO;
using System.IO;
using System.Threading.Tasks;

namespace FormatLines.Tests.Infrastructure
{
	internal class StringLineReader : ILineReader
	{
		private readonly ILineReader _innerReader;

		public StringLineReader(string input)
		{
			_innerReader = new LineReader(new StringReader(input));
		}

		public void Dispose()
		{
			_innerReader.Dispose();
		}

		public Task<string?> ReadLineAsync()
		{
			return _innerReader.ReadLineAsync();
		}
	}
}
