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

    [Fact]
    public void TestInsertionSort()
    {
        // Given
        int[] input = [-11, 12, -42, 0, 1, 90, 68, 6, -9];
        
        // When
        InsertionSort(input);
        
        // Then
        var joinedResult = String.Join(" | " , input);
        Assert.Equal("-42 | -11 | -9 | 0 | 1 | 6 | 12 | 68 | 90", joinedResult);
        
        return;

        void InsertionSort(int[] ints)
        {
            for (int i = 1; i < ints.Length; i++)
            {
                int j = i;
                while (j > 0 && ints[j] < ints[j - 1])
                {
                    (ints[j], ints[j - 1]) = (ints[j - 1], ints[j]);
                    j--;
                }
            }
        }
    }


    [Fact]
    public void TestMergeSort()
    {
        // Given
        int[] input = [-11, 12, -42, 0, 90, -9];
        
        // When
        MergeSort(input);
        
        // Then
        var joinedResult = String.Join(" | " , input);
        Assert.Equal("-42 | -11 | -9 | 0 | 12 | 90", joinedResult);
        
        return;

        void MergeSort(int[] a)
        {
            if (a.Length <= 1) { return; }
            int m = a.Length / 2;
            int[] left = GetSubarray(a, 0, m - 1);
            int[] right = GetSubarray(a, m, a.Length - 1);
            MergeSort(left);
            MergeSort(right);
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j]) { a[k] = left[i++]; }
                else { a[k] = right[j++]; }
                k++;
            }
            while (i < left.Length) { a[k++] = left[i++]; }
            while (j < right.Length) { a[k++] = right[j++]; }           
        }
        
        int[] GetSubarray(int[] a, int si, int ei)
        {
            int[] result = new int[ei - si + 1];
            Array.Copy(a, si, result, 0, ei - si + 1);
            return result;
        }
    }
}