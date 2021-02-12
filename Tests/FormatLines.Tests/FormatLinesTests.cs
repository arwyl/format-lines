using FormatLines.Tests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace FormatLines.Tests
{
	[TestClass]
	public class FormatLinesTests : TestBase
	{
		[TestMethod]
		public async Task Should_TrimLines()
		{
			await TestRunner.RunAsync(
				arrange => arrange
					.WithInput("\t  123   ", "1\t\t", "    2")
					.WithTrimLines(), 
				assert => assert.ResultShouldBe("123", "1", "2")
			);
		}

		[TestMethod]
		public async Task Should_RemoveEmptyLines()
		{
			await TestRunner.RunAsync(
				arrange => arrange
					.WithInput("1", "", "2", " ", "3", "")
					.WithIgnoreEmptyLines(),
				assert => assert.ResultShouldBe("1", "2", " ", "3")
			);
		}

		[TestMethod]
		public async Task Should_RemoveLinesByMinLength()
		{
			await TestRunner.RunAsync(
				arrange => arrange
					.WithInput("111", "", "222", " ", "3", "44")
					.WithMinLineLength(2),
				assert => assert.ResultShouldBe("111", "222", "44")
			);
		}

		[TestMethod]
		public async Task Should_UseCustomDelimiter()
		{
			await TestRunner.RunAsync(
				arrange => arrange
					.WithInput("1", "2", "3")
					.WithDelimiter("_"),
				assert => assert.ResultShouldBe("1_2_3")
			);
		}

		[TestMethod]
		public async Task Should_TrimLinesBeforeRemovingEmptyLines()
		{
			await TestRunner.RunAsync(
				arrange => arrange
					.WithInput("1", "  \t\t    ", "2", "\t   \t", "3")
					.WithTrimLines()
					.WithIgnoreEmptyLines(),
				assert => assert.ResultShouldBe("1", "2", "3")
			);
		}

		[TestMethod]
		public async Task Should_TrimLinesBeforeApplyingMinLength()
		{
			await TestRunner.RunAsync(
				arrange => arrange
					.WithInput("11", "  \t\t    ", "22", "\t   \t", "33")
					.WithTrimLines()
					.WithMinLineLength(2),
				assert => assert.ResultShouldBe("11", "22", "33")
			);
		}
	}
}
