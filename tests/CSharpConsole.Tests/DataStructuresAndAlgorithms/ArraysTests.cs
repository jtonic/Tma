using System.Globalization;
using System.Text;
using Xunit;
using static Xunit.Assert;

namespace CSharpConsole.Tests.DataStructuresAndAlgorithms;

public class ArraysTests
{
    private readonly int[] _numbers = [9, -11, 6, -12, 1];

    [Fact]
    public void TestArrays()
    {
        // Access elements
        Console.WriteLine("\nAccess elements");
        var middle = _numbers[2];
        Equal(6, middle);
        var last = _numbers[^1];
        Equal(1, last);
        var beforeLast = _numbers[^2];
        Equal(-12, beforeLast);

        // Array length
        Console.WriteLine("\nArray length");
        Console.Write(_numbers.Length);
        Equal(5, _numbers.Length);

        // check the dimension of the array
        Console.WriteLine("\nArray dimension");
        Console.Write(_numbers.Rank);
        Equal(1, _numbers.Rank);

        // check if an element exists
        Console.WriteLine("\nCheck if an element exists");
        var exists = Array.Exists(_numbers, n => n == -12);
        True(exists);

        // Test if all elements meet a condition
        True(Array.TrueForAll(_numbers, i => i > -100));

        // Print elements
        Console.WriteLine("\nPrint all elements");
        Console.Write(_numbers.Join());

        //Copy array elements to a new one
        var newNumbers = new int[_numbers.Length];
        Array.Copy(_numbers, newNumbers, _numbers.Length);

        Console.WriteLine(string.Join(' ', _numbers));

        // Partial reverse
        Console.WriteLine("\nPartial reverse");
        Array.Reverse(newNumbers, 1, 2);
        Console.WriteLine(_numbers.Join());
        Console. WriteLine(newNumbers.Join());

        // Sort array
        Console.WriteLine("\nSort array");
        var newNumbers2 = new int[_numbers.Length];
        Array.Copy(_numbers, newNumbers2, _numbers.Length);
        Array.Sort(newNumbers2);
        Console.Write(newNumbers2.Join());

        // Fill array with a value
        Console.WriteLine("\nFill array with a value");
        var newNumbers3 = new int[_numbers.Length];
        Array.Copy(_numbers, newNumbers3, _numbers.Length);
        Array.Fill(newNumbers3, 5);
        Console.WriteLine(newNumbers3.Join());

        // Clear all elements to default
        Console.WriteLine("\nClear elements to default values");
        Array.Clear(newNumbers3);
        Console.WriteLine(newNumbers3.Join());
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
        Console.WriteLine(months.Join());
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
        Console.OutputEncoding = Encoding.UTF8;


        for (var r = 0; r < map.GetLength(0); r++)
        {
            for (var c = 0; c < map.GetLength(1); c++)
            {
                Console.ForegroundColor = GetColor(map[r, c]);
                Console.Write(GetChar(map[r, c]) + " ");
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    [Fact]
    public void TestJaggedArray()
    {
        int[][] numbers =
        [
            [9, 5],
            [0, -3, 12],
            null!,
            [54]
        ];
        Equal(4, numbers.GetLength(0));
        Null(numbers[2]);
    }

    [Fact]
    public void TestTransportTable()
    {
        var enumLength = Enum.GetNames<TransportationMean>().Length;
        Random rand = new();
        var currentTransportationMean = rand.Next(enumLength);
        Console.WriteLine(currentTransportationMean);

        var transportationMeans = new TransportationMean[12][]; 
        for (var m = 1; m <= 12; m++)
        {
            var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, m);
            transportationMeans[m - 1] = new TransportationMean[daysInMonth];
            for (var d = 1; d <= daysInMonth; d++)
            {
                transportationMeans[m - 1][d - 1] = (TransportationMean)rand.Next(enumLength);
            }
        }
        PrintTransportationMeans(transportationMeans);
        return;

        void PrintTransportationMeans(TransportationMean[][] means)
        {
            string[] months = GetMonthsNames();
            var nameLength = months.Max(n => n.Length) + 2;
            for (var m = 1; m <= 12; m++)
            {
                var month = months[m - 1];
                Console.Write($"{month}:".PadRight(nameLength));
                for (int d = 1; d <= means[m - 1].Length; d++)
                {
                    var mean = means[m - 1][d - 1];
                    (char character, ConsoleColor color) = Get(mean);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = color;
                    Console.Write(character);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.WriteLine();
            } 
        }

        (char character, ConsoleColor color) Get(TransportationMean mean)
        {
            return mean switch
            {
                TransportationMean.Bike => ('B', ConsoleColor.Blue),
                TransportationMean.Bus => ('U', ConsoleColor.DarkGreen),
                TransportationMean.Car => ('C', ConsoleColor.Red),
                TransportationMean.Subway => ('S', ConsoleColor.Magenta),
                TransportationMean.Walk => ('W', ConsoleColor.DarkYellow),
                _ => throw new Exception("Unknown type")
            };
        }
        
        string[] GetMonthsNames()
        {
            CultureInfo culture = new("en");

            var result = new string[12];
            foreach (int m in Enumerable.Range(1, 12))
            {
                var firstDayOfMonth = new DateTime(DateTime.Now.Year, m, 1);
                var monthName = firstDayOfMonth.ToString("MMMM", culture);
                result[m - 1] = monthName;
            }
            return result;
        }
    }
    private enum TransportationMean
    {
        Walk,
        Bike,
        Bus,
        Car,
        Subway
    }
}
