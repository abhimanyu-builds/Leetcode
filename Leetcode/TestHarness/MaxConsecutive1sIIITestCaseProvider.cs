using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.MaxConsecutive1sIII)]
public class MaxConsecutive1sIIITestCaseProvider : ITestCaseProvider<MaxConsecutive1sIIIInput, int>
{
    public List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase>();
        cases.AddRange(GetStaticTestCases());
        cases.AddRange(GetEdgeCases());
        cases.AddRange(GetContrastCases());
        cases.AddRange(GetFlipStrategyCases());
        cases.AddRange(GenerateRandomizedCases());
        return cases;
    }

    private static List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase> GetStaticTestCases() => new()
    {
        new(new([1, 1, 0, 1, 1, 1], 1), 6),
        new(new([1, 0, 1, 0, 1], 1), 3),
        new(new([1, 1, 1, 1, 1], 0), 5),
        new(new([0, 0, 0, 0], 2), 2),
        new(new([1], 0), 1),
        new(new([0], 1), 1),
        new(new([1, 1, 0, 1, 1, 0, 1], 2), 7),
        new(new([1, 0, 0, 0, 1, 1], 1), 3),
        new(new([0, 0, 1, 1, 1, 0, 1], 2), 6),
    };

    private static List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase> GetEdgeCases() => new()
    {
        new(new([], 0), 0),
        new(new([1], 0), 1),
        new(new([0], 0), 0),
        new(new([1, 1, 1, 1, 1, 1, 1], 3), 7),
        new(new([0, 0, 0, 0, 0], 5), 5),
        new(new([1, 1, 1, 1, 1], 10), 5),
    };

    private static List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase> GetContrastCases() => new()
    {
        new(new([1, 1, 1, 1, 1, 0, 0, 0], 2), 7),
        new(new([0, 0, 0, 1, 1, 1, 1, 1], 3), 8),
        new(new([1, 0, 1, 0, 1, 0, 1], 2), 5),
        new(new([0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0], 3), 7),
        new(new([1, 0, 1, 0, 1, 0, 1, 0], 1), 3),
        new(new([1, 1, 1, 1, 1, 1, 1, 1], 0), 8),
        new(new([0, 0, 0, 0, 0, 0], 0), 0),
        new(new([0, 0, 1, 0, 0], 1), 2),
        new(new(Enumerable.Repeat(0, 1000).Concat(Enumerable.Repeat(1, 500)).Concat(Enumerable.Repeat(0, 1000)).ToArray(), 5), 505),
    };

    private static List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase> GetFlipStrategyCases() => new()
    {
        // Zero cluster in middle
        new(new([1, 1, 0, 0, 0, 1, 1], 2), 4),

        // Scattered zeroes
        new(new([1, 0, 1, 0, 1, 0, 1], 2), 5),

        // Flip shrinking window (k exceeded)
        new(new([1, 0, 0, 0, 1, 1, 0, 1], 2), 5),

        // Flip all zeroes (k = count of zeroes)
        new(new([0, 0, 1, 1, 0, 1], 3), 6),
        new(new([1, 1, 0, 0, 0, 1, 1], 3), 7),

        // Flip none (k = 0)
        new(new([1, 0, 1, 0, 1], 0), 1),

        // Flip all (k > zeroes)
        new(new([1, 0, 1, 0, 1], 10), 5),
    };

    private List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<MaxConsecutive1sIIIInput, int>.TestCase>();
        int[] sizes = { 10, 100, 1_000, 10_000, 50_000 };

        foreach (int size in sizes)
        {
            var array = Enumerable.Range(0, size).Select(_ => rand.Next(0, 2)).ToArray();
            int zeroCount = array.Count(x => x == 0);
            int k = rand.Next(0, Math.Min(zeroCount + 1, size / 2)); // reasonable k

            int maxLen = ComputeMaxConsecutiveOnes(array, k);
            cases.Add(new(new(array, k), maxLen));
        }

        return cases;
    }

    private static int ComputeMaxConsecutiveOnes(int[] nums, int k)
    {
        int left = 0, right = 0, zeroes = 0, maxLen = 0;
        while (right < nums.Length)
        {
            if (nums[right] == 0) zeroes++;
            while (zeroes > k)
            {
                if (nums[left++] == 0) zeroes--;
            }
            maxLen = Math.Max(maxLen, right - left + 1);
            right++;
        }
        return maxLen;
    }
}