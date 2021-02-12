using System;
using System.IO;
using System.Threading.Tasks;

namespace FormatLines.IO
{
	public class LineReader : ILineReader
	{
		private readonly TextReader _innerReader;

		public LineReader(TextReader innerReader)
		{
			_innerReader = innerReader;
		}

		public Task<string?> ReadLineAsync()
		{
			return _innerReader.ReadLineAsync();
		}

		public void Dispose()
		{
			_innerReader.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
