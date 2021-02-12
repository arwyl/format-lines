using System;
using System.Threading.Tasks;

namespace FormatLines.IO
{
	public interface ILineWriter : IAsyncDisposable
	{
		Task AppendLineAsync(string value);

		Task WriteAsync(string value);
	}
}