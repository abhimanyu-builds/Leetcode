using Leetcode.Interfaces;
using Leetcode.Models;
using Leetcode.TestHarness;

public class TwoSumSortedTestCaseProvider : ITestCaseProvider<TwoSumSortedInput, int[]>
{
    public List<ProblemTest<TwoSumSortedInput, int[]>.TestCase> GetTestCases()
    {
        List<ProblemTest<TwoSumSortedInput, int[]>.TestCase> cases = GetStaticTestCases();
        cases.AddRange(GenerateRandomizedCases());
        return cases;
    }

    private static List<ProblemTest<TwoSumSortedInput, int[]>.TestCase> GetStaticTestCases()
    {
        //strictly one solution per case
        var cases = new List<ProblemTest<TwoSumSortedInput, int[]>.TestCase>
        {
            new(new TwoSumSortedInput([2, 7, 11, 15], 9), [1, 2]),           // basic match
            new(new TwoSumSortedInput([1, 2, 3, 4, 6], 10), [4, 5]),         // match at end
            new(new TwoSumSortedInput([1, 1, 1, 1, 1], 2), [1, 2], ValidateBySum:true),          // repeated values
            new(new TwoSumSortedInput([-5, -4, -3, -2, -1], -8), [3, 5], ValidateBySum:true),    // all negative
            new(new TwoSumSortedInput([-10, -5, 0, 5, 10], 0), [2, 4], ValidateBySum:true),      // mixed signs
            new(new TwoSumSortedInput([0, 0], 0), [1, 2]),                   // zeroes
            new(new TwoSumSortedInput([1, 2], 3), [1, 2]),                   // minimum length
            new(new TwoSumSortedInput([1, 2, 3, 4, 5], 3), [1, 2]),          // match at start
            new(new TwoSumSortedInput([1, 2, 3, 4, 5], 9), [4, 5]),          // match at end
            new(new TwoSumSortedInput([1, 2, 3, 4, 4, 5], 8), [3, 6]),       // duplicate match
            new(new TwoSumSortedInput(Enumerable.Range(1, 100000).ToArray(), 199999), [99999, 100000]) // large input
        };
        return cases;
    }

    private List<ProblemTest<TwoSumSortedInput, int[]>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<TwoSumSortedInput, int[]>.TestCase>();
        Random rand = new();
        int size = rand.Next(10, 1000);
        int min = rand.Next(-10000, 0);
        int max = rand.Next(min, 10000);
        int[] array = GenerateRandomSortedArray(size, min, max);

        for (int t = 0; t < rand.Next(10, 100); t++)
        {
            //Doesn't guarantee unique solution. But the solution is guaranteed to be present. Result to be verified with sum match
            int i = rand.Next(0, size - 1);
            int j = rand.Next(i + 1, size);
            int target = array[i] + array[j];
            testCases.Add(new(new TwoSumSortedInput(array, target), [i, j], ValidateBySum: true));                                            // Basic match
            testCases.Add(new(new TwoSumSortedInput(array, array[size - 2] + array[size - 1]), [size - 2, size - 1], ValidateBySum: true));   // Match at end
        }

        return testCases;
    }

    public static int[] GenerateRandomSortedArray(int size, int minValue, int maxValue)
    {
        int[] array = new int[size];
        Random rand = new();
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(minValue, maxValue + 1);
        }
        Array.Sort(array);
        return array;
    }
}
