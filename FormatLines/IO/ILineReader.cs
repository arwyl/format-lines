using System;
using System.Threading.Tasks;

namespace FormatLines.IO
{
	public interface ILineReader : IDisposable
	{
		Task<string?> ReadLineAsync();
	}
}
