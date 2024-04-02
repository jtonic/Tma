using Xunit;

namespace CSharpConsole.Tests.DataStructuresAndAlgorithms;

public class SortAlgorithmsTests
{
    [Fact]
    public void TestSelectionSort()
    {
        // Given
        int[] input = [-11, 12, -42, 0, 1, 90, 68, 6, -9];
        
        // When
        SelectionSort(input);
        
        // Then
        var joinedResult = String.Join(" | " , input);
        Assert.Equal("-42 | -11 | -9 | 0 | 1 | 6 | 12 | 68 | 90", joinedResult);
        
        return;

        // Definitions
        void SelectionSort(int[] ints)
        {
            for (int i = 0; i < ints.Length - 1; i++)
            {
                var minIdx = i;
                var minValue = ints[i];
                for (int j = i + 1; j < ints.Length; j++)
                {
                    if (ints[j] < minValue)
                    {
                        minIdx = j;
                        minValue = ints[j];
                    }
                }
                (ints[i], ints[minIdx]) = (ints[minIdx], ints[i]);
            }
        }
    }
}