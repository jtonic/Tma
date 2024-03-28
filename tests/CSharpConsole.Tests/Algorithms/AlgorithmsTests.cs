using Xunit;

namespace CSharpConsole.Tests.Algorithms;


public class AlgorithmsTests
{
    [Fact]
    public void TestArithmeticMean()
    {
        Console.WriteLine("TestArithmeticMean");
        Console.Write("n = ");
        int.TryParse(Console.ReadLine(), out var n);
        if (n == 0)
        {
            Console.WriteLine("No result.");
        } else
        {
            var sum = 0.0;
            var i = 0;
            do
            {
                Console.Write("x = ");
                int.TryParse(Console.ReadLine(), out var x);
                sum += x;
                i++;
            }
            while (i != n);

            var result = sum / n;
            Console.WriteLine($"Arithmetic mean = {result}");
        }
    }

    [Fact]
    public void TestFactorial()
    {
        Assert.Equal(6, Factorial(3));
        return;

        int Factorial(int n, int acc = 1) =>
            n == 0 ? acc : Factorial(n - 1, acc * n);
    }
}
