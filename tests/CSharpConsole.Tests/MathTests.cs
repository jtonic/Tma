using Xunit;

namespace CSharpConsole.Tests
{
    public class MathTests
    {
        [Fact]
        public void AddTwoIntegersTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }
    }
}