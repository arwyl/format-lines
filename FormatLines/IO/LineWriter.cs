using System;
using System.IO;
using System.Threading.Tasks;

namespace FormatLines.IO
{
	public class LineWriter : ILineWriter
	{
		private readonly TextWriter _innerWriter;

		private readonly Func<string, Task> _appendLineFunc;

		public LineWriter(TextWriter innerWriter, string delimiter)
		{
			_innerWriter = innerWriter;

			_appendLineFunc = string.IsNullOrEmpty(delimiter) 
				? InnerWriteAsync
				: async value =>
					{
						await _innerWriter.WriteAsync(delimiter);
						await InnerWriteAsync(value);
					};
		}

		public virtual Task WriteAsync(string value)
		{
			return InnerWriteAsync(value);
		}

		public virtual Task AppendLineAsync(string value)
		{
			return _appendLineFunc(value);
		}

		private Task InnerWriteAsync(string value)
		{
			return _innerWriter.WriteAsync(value);
		}

		public ValueTask DisposeAsync()
		{
			return _innerWriter.DisposeAsync();
		}
	}
}
