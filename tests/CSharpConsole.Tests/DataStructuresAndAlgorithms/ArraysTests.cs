using System.Globalization;
using System.Text;
using Xunit;
using static Xunit.Assert;
using static System.Console;

namespace CSharpConsole.Tests.DataStructuresAndAlgorithms;

public class ArraysTests
{
    private readonly int[] _numbers = [9, -11, 6, -12, 1];

    [Fact]
    public void TestArrays()
    {
        // Access elements
        WriteLine("\nAccess elements");
        var middle = _numbers[2];
        Equal(6, middle);
        var last = _numbers[^1];
        Equal(1, last);
        var beforeLast = _numbers[^2];
        Equal(-12, beforeLast);

        // Array length
        WriteLine("\nArray length");
        Write(_numbers.Length);
        Equal(5, _numbers.Length);

        // check the dimension of the array
        WriteLine("\nArray dimension");
        Write(_numbers.Rank);
        Equal(1, _numbers.Rank);

        // check if an element exists
        WriteLine("\nCheck if an element exists");
        var exists = Array.Exists(_numbers, n => n == -12);
        True(exists);

        // Test if all elements meet a condition
        True(Array.TrueForAll(_numbers, i => i > -100));

        // Print elements
        WriteLine("\nPrint all elements");
        Write(_numbers.Join());

        //Copy array elements to a new one
        var newNumbers = new int[_numbers.Length];
        Array.Copy(_numbers, newNumbers, _numbers.Length);

        WriteLine(string.Join(' ', _numbers));

        // Partial reverse
        WriteLine("\nPartial reverse");
        Array.Reverse(newNumbers, 1, 2);
        WriteLine(_numbers.Join());
        WriteLine(newNumbers.Join());

        // Sort array
        WriteLine("\nSort array");
        var newNumbers2 = new int[_numbers.Length];
        Array.Copy(_numbers, newNumbers2, _numbers.Length);
        Array.Sort(newNumbers2);
        Write(newNumbers2.Join());

        // Fill array with a value
        WriteLine("\nFill array with a value");
        var newNumbers3 = new int[_numbers.Length];
        Array.Copy(_numbers, newNumbers3, _numbers.Length);
        Array.Fill(newNumbers3, 5);
        WriteLine(newNumbers3.Join());

        // Clear all elements to default
        WriteLine("\nClear elements to default values");
        Array.Clear(newNumbers3);
        WriteLine(newNumbers3.Join());
    }

    [Fact]
    public void TestMonthsOfTheYear()
    {
        var months = new string[12];
        CultureInfo cultureInfo = new("en");
        for (int month = 1; month <= 12; month++)
        {
            DateTime firstDay = new(DateTime.Now.Year, month, 1);
            var monthName = firstDay.ToString("MMMM", cultureInfo);
            months[month - 1] = monthName;
        }
        WriteLine(months.Join());
    }

    [Fact]
    public void TestColoredConsole()
    {
        char[,] map = {
            {'s', 's', 's', 'g', 'g', 'g', 'g', 'g'},
            {'s', 's', 's', 'g', 'g', 'g', 'g', 'g'},
            {'s', 's', 's', 's', 's', 'b', 'b', 'b'},
            {'s', 's', 's', 's', 's', 'b', 's', 's'},
            {'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w'},
        };

        static ConsoleColor GetColor(char terrain) =>
            terrain switch
            {
                's' => ConsoleColor.Yellow,
                'w' => ConsoleColor.Blue,
                'g' => ConsoleColor.Green,
                _ => ConsoleColor.Gray
            };

        static char GetChar(char terrain) =>
            terrain switch
            {
                's' => '\u25cb',
                'w' => '\u2248',
                'g' => '\u201c',
                _ => '\u25cf'

            };
        OutputEncoding = Encoding.UTF8;


        for (var r = 0; r < map.GetLength(0); r++)
        {
            for (var c = 0; c < map.GetLength(1); c++)
            {
                ForegroundColor = GetColor(map[r, c]);
                Write(GetChar(map[r, c]) + " ");
            }
            WriteLine();
        }
        ResetColor();
    }
}
