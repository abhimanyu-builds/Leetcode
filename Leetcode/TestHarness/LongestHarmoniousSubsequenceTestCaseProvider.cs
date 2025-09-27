using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.LongestHarmoniousSubsequence)]
public class LongestHarmoniousSubsequenceTestCaseProvider : ITestCaseProvider<int[], int>
{
    public List<ProblemTest<int[], int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], int>.TestCase>();
        cases.AddRange(GetStaticTestCases());
        cases.AddRange(GetEdgeCases());
        cases.AddRange(GetContrastCases());
        cases.AddRange(GenerateRandomizedCases());
        return cases;
    }

    private static List<ProblemTest<int[], int>.TestCase> GetStaticTestCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
        {
            new([1, 3, 2, 2, 5, 2, 3, 7], 5),
            new([1, 2, 3, 4], 2),
            new([1, 1, 1, 1], 0),
            new([1, 2, 2, 1], 4),
            new([1, 2, 3, 3, 2, 2, 2], 6),
        };
    }

    private static List<ProblemTest<int[], int>.TestCase> GetEdgeCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
        {
            new([], 0),
            new([10], 0),
            new([10, 11], 2),
            new([10, 12], 0),
            new([10, 10, 11, 11, 11], 5),
            new(Enumerable.Repeat(42, 1000).ToArray(), 0),
        };
    }
    private static List<ProblemTest<int[], int>.TestCase> GetContrastCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
        {
            // Dense harmonious cluster
            new([1, 2, 2, 3, 3, 4], 4),

            // Sparse values with single harmonious pair
            new([100, 101, 102, 103], 2),

            // Uniformly increasing, low frequency
            new([1, 2, 3, 4, 5, 6], 2),

            // High frequency overlap
            new([1, 2, 2, 3, 3, 3, 4], 5),

            // Maximal overlap
            new([1, 2, 2, 2, 3, 3, 3, 3], 7),

            // All values same
            new(Enumerable.Repeat(42, 1000).ToArray(), 0),

            // Alternating harmonious pairs
            new([1, 2, 3, 4, 5, 6, 7, 8], 2),

            // Large block of one value followed by its neighbor
            new(Enumerable.Repeat(1000, 500).Concat(Enumerable.Repeat(1001, 500)).ToArray(), 1000),

            // Large block with no harmonious neighbor
            new(Enumerable.Repeat(999, 1000).ToArray(), 0),

            // Multiple harmonious blocks
            new(Enumerable.Repeat(10, 300).Concat(Enumerable.Repeat(11, 300))
                .Concat(Enumerable.Repeat(20, 200)).Concat(Enumerable.Repeat(21, 200)).ToArray(), 600),
        };
    }
    private List<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<int[], int>.TestCase>();
        Random rand = new();

        for (int t = 0; t < 10; t++)
        {
            int size = rand.Next(5000, 20000); // Stress range
            int clusterCount = rand.Next(5, 20);
            var nums = new List<int>();

            for (int c = 0; c < clusterCount; c++)
            {
                int baseVal = rand.Next(-1_000_000_000, 1_000_000_000);
                int freqA = rand.Next(100, 1000);
                int freqB = rand.Next(100, 1000);

                nums.AddRange(Enumerable.Repeat(baseVal, freqA));
                nums.AddRange(Enumerable.Repeat(baseVal + 1, freqB));
            }

            int[] arr = nums.OrderBy(_ => rand.Next()).ToArray(); // Shuffle

            var freq = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int max = 0;
            foreach (var key in freq.Keys)
            {
                if (freq.ContainsKey(key + 1))
                    max = Math.Max(max, freq[key] + freq[key + 1]);
            }

            testCases.Add(new(arr, max));
        }

        return testCases;
    }
}