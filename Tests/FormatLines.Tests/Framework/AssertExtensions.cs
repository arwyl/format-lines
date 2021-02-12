using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormatLines.Tests.Framework
{
	public static class AssertExtensions
	{
		public static IAssertParameters ResultShouldBe(this IAssertParameters pars, string expectedOutput)
		{
			Assert.AreEqual(expectedOutput, pars.Result);
			return pars;
		}

		public static IAssertParameters ResultShouldBe(this IAssertParameters pars, params string[] expectedLines)
		{
			var expectedOutput = string.Join(pars.Delimiter, expectedLines);
			Assert.AreEqual(expectedOutput, pars.Result);
			return pars;
		}
	}
}
