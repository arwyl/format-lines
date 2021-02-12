using FormatLines.IO;
using System.IO;
using System.Threading.Tasks;

namespace FormatLines.Tests.Infrastructure
{
	internal class StringLineWriter : ILineWriter
	{
		private readonly StringWriter _stringWriter;

		private readonly ILineWriter _innerWriter;

		public StringLineWriter(string delimiter)
		{
			_stringWriter = new StringWriter();
			_innerWriter = new LineWriter(_stringWriter, delimiter);
		}

		public async Task<string> GetResultAsync()
		{
			await _stringWriter.FlushAsync();

			return _stringWriter.GetStringBuilder().ToString();
		}

		public Task AppendLineAsync(string value)
		{
			return _innerWriter.AppendLineAsync(value);
		}

		public Task WriteAsync(string value)
		{
			return _innerWriter.WriteAsync(value);
		}

		public ValueTask DisposeAsync()
		{
			return _innerWriter.DisposeAsync();
		}
	}
}
