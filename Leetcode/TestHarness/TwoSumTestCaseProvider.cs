using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.TwoSum)]
public class TwoSumTestCaseProvider : ITestCaseProvider<TwoSumInput, int[]>
{
    public List<ProblemTest<TwoSumInput, int[]>.TestCase> GetTestCases()
    {
        List<ProblemTest<TwoSumInput, int[]>.TestCase> cases = GetStaticTestCases();
        cases.AddRange(GenerateRandomizedCases());

        return cases;

    }

    private static List<ProblemTest<TwoSumInput, int[]>.TestCase> GetStaticTestCases()
    {
        //strictly one solution per case
        var cases = new List<ProblemTest<TwoSumInput, int[]>.TestCase>
        {
            new(new TwoSumInput([3, 2, 4], 6), [1, 2]),                // off-by-one check
            new(new TwoSumInput([-2, -1, 0, 1, 2], 3), [3, 4]),
            new(new TwoSumInput([2, 7, 11, 15], 9), [0, 1]),           // basic match
            new(new TwoSumInput([1, 2, 3, 4, 6], 10), [3, 4]),         // match at end
            new(new TwoSumInput([5, 75, 25], 100), [1, 2]),            // match in middle
            new(new TwoSumInput([3, 3], 6), [0, 1]),                   // duplicate values
            new(new TwoSumInput([0, 4, 3, 0], 0), [0, 3]),             // zeroes
            new(new TwoSumInput([-1, -2, -3, -4, -5], -8), [2, 4]),    // all negative
            new(new TwoSumInput([-10, 20, 10, -5], 0), [0, 2]),        // mixed signs
            new(new TwoSumInput([1, 2], 3), [0, 1]),                   // minimum length
            new(new TwoSumInput([1, 1, 1, 1, 1, 1], 2), [0, 1]),       // repeated values
            new(new TwoSumInput([3, 3], 6), [0, 1]),                   // repeated values & min length
            new(new TwoSumInput(Enumerable.Range(1, 100000).ToArray(), 199999), [99998, 99999]), // large input
        };
        return cases;
    }

    private List<ProblemTest<TwoSumInput, int[]>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<TwoSumInput, int[]>.TestCase>();
        Random rand = new();
        int size = rand.Next(10, 1000);
        int min = rand.Next(-10000, 0);
        int max = rand.Next(min, 10000);
        int[] array = GenerateRandomArray(size, min, max);

        for (int t = 0; t < rand.Next(10, 100); t++)
        {
            //Doesn't guarantee unique solution. But the solution is guaranteed to be present. Result to be verified with sum match
            int i = rand.Next(0, size - 1);
            int j = rand.Next(i + 1, size);
            int target = array[i] + array[j];
            testCases.Add(new(new TwoSumInput(array, target), [i, j], ValidateBySum: true));                                            // Basic match
            testCases.Add(new(new TwoSumInput(array, array[size - 2] + array[size - 1]), [size - 2, size - 1], ValidateBySum: true));   // Match at end
        }

        return testCases;
    }

    public static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        int[] array = new int[size];
        Random rand = new();
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(minValue, maxValue + 1);
        }
        return array;
    }
}
