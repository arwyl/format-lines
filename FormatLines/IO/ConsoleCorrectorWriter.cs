using System;
using System.Threading.Tasks;

namespace FormatLines.IO
{
	/// <summary>
	/// Writer for custom case: delimiter is new line, not redirected stdin as input and not redirected stdout as output.
	/// This writer always adds new line after writing line
	/// </summary> 
	internal class ConsoleCorrectorWriter : ILineWriter
	{
		public Task AppendLineAsync(string value)
		{
			return WriteAsync(value);
		}

		public ValueTask DisposeAsync()
		{
			return ValueTask.CompletedTask;
		}

		public Task WriteAsync(string value)
		{
			Console.WriteLine(value);
			return Task.CompletedTask;
		}
	}
}
