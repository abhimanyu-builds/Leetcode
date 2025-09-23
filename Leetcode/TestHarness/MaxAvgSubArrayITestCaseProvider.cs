using Leetcode.Interfaces;
using Leetcode.Models;
using Leetcode.TestHarness;

public class MaxAvgSubArrayITestCaseProvider : ITestCaseProvider<MaxAvgSubArrayInput, double>
{
    public List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase> GetTestCases()
    {
        List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase> cases = GetStaticTestCases();
        cases.AddRange(GetEdgeCases());
        cases.AddRange(GenerateRandomizedCases());
        return cases;
    }

    private static List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase> GetStaticTestCases()
    {
        var cases = new List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase>
        {
            new(new MaxAvgSubArrayInput([1, 12, -5, -6, 50, 3], 4), 12.75),       // general
            new(new MaxAvgSubArrayInput([5, 5, 5, 5, 5], 3), 5),                  // uniform values
            new(new MaxAvgSubArrayInput([-1, -2, -3, -4], 2), -1.5),              // all negative
            new(new MaxAvgSubArrayInput([0, 0, 0, 0], 2), 0),                     // all zeroes
            new(new MaxAvgSubArrayInput([1, 2, 3, 4, 5], 1), 5),                  // k = 1, max element
            new(new MaxAvgSubArrayInput([1, 2, 3, 4, 5], 5), 3),                  // full array
            new(new MaxAvgSubArrayInput([100000, -100000], 1), 100000),          // edge values
            new(new MaxAvgSubArrayInput([1, 2, 3, 4, 5, 6], 2), 5.5),             // increasing sequence
            new(new MaxAvgSubArrayInput([6, 5, 4, 3, 2, 1], 2), 5.5),             // decreasing sequence
            new(new MaxAvgSubArrayInput([1, 2], 2), 1.5),                         // minimum length
            new(new MaxAvgSubArrayInput([1, 1, 1, 1, 1], 2), 1),                  // repeated values
            new(new MaxAvgSubArrayInput(Enumerable.Range(1, 100000).ToArray(), 2), 99999.5), // large input
        };
        return cases;
    }

    private List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase>();
        Random rand = new();
        for (int t = 0; t < rand.Next(10, 50); t++)
        {
            int size = rand.Next(10, 1000);
            int k = rand.Next(1, size);
            int[] array = GenerateRandomArray(size, -10000, 10000);

            double maxAvg = double.MinValue;
            for (int i = 0; i <= array.Length - k; i++)
            {
                double sum = 0;
                for (int j = i; j < i + k; j++)
                    sum += array[j];
                maxAvg = Math.Max(maxAvg, sum / k);
            }

            testCases.Add(new(new MaxAvgSubArrayInput(array, k), maxAvg));
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

    private static List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase> GetEdgeCases()
    {
        var cases = new List<ProblemTest<MaxAvgSubArrayInput, double>.TestCase>
        {
            // 🔹 k = 1 → should return the max element
            new(new MaxAvgSubArrayInput([1, 2, 3, 4, 5], 1), 5),
            new(new MaxAvgSubArrayInput([-5, -4, -3, -2, -1], 1), -1),
            new(new MaxAvgSubArrayInput([100000, -100000], 1), 100000),

            // 🔹 k = nums.Length → should return average of entire array
            new(new MaxAvgSubArrayInput([1, 2, 3, 4, 5], 5), 3),
            new(new MaxAvgSubArrayInput([-5, -5, -5, -5], 4), -5),
            new(new MaxAvgSubArrayInput([0, 0, 0, 0], 4), 0),

            // 🔹 k > nums.Length → invalid input, should be handled gracefully
            new(new MaxAvgSubArrayInput([1, 2, 3], 5), 0),
            new(new MaxAvgSubArrayInput([], 1), 0),
            new(new MaxAvgSubArrayInput([42], 2), 0),
        };

        return cases;
    }
}