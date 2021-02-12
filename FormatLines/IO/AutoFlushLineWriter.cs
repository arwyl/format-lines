using System.IO;
using System.Threading.Tasks;

namespace FormatLines.IO
{
	public class AutoFlushLineWriter : LineWriter
	{
		private readonly TextWriter _innerWriter;

		public AutoFlushLineWriter(TextWriter innerWriter, string delimiter) : base(innerWriter, delimiter)
		{
			_innerWriter = innerWriter;
		}

		public override async Task WriteAsync(string value)
		{
			await base.WriteAsync(value);
			await _innerWriter.FlushAsync();
		}

		public override async Task AppendLineAsync(string value)
		{
			await base.AppendLineAsync(value);
			await _innerWriter.FlushAsync();
		}
	}
}
