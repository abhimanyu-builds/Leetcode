using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.LongestSubarrayAfterOneDeletion)]
public class LongestSubarrayAfterOneDeletionTestCaseProvider : ITestCaseProvider<int[], int>
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
            new([1, 1, 0, 1, 1, 1], 5),
            new([1, 0, 1, 0, 1], 2),
            new([1, 1, 1, 1, 1], 4),
            new([0, 0, 0, 0], 0),
            new([1], 0),
            new([0], 0),
            new([1, 1, 0, 1, 1, 0, 1], 4),
            new([1, 0, 0, 0, 1, 1], 2),
            new([0, 0, 1, 1, 1, 0, 1], 4),
        };
    }

    private static List<ProblemTest<int[], int>.TestCase> GetEdgeCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
        {
            new([], 0),
            new([1], 0),
            new([0], 0),
            new([1, 1, 1, 1, 1, 1, 1], 6),
        };
    }

    private static List<ProblemTest<int[], int>.TestCase> GetContrastCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
        {
            new([1, 1, 1, 1, 1, 0, 0, 0], 5),
            new([0, 0, 0, 1, 1, 1, 1, 1], 5),
            new([1, 0, 1, 0, 1, 0, 1], 2),
            new([0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0], 4),
            new([1, 0, 1, 0, 1, 0, 1, 0], 2),
            new([1, 1, 1, 1, 1, 1, 1, 1], 7),
            new([0, 0, 0, 0, 0, 0], 0),
            new([0, 0, 1, 0, 0], 1),
            new([], 0),
            new(Enumerable.Repeat(0, 1000).Concat(Enumerable.Repeat(1, 500)).Concat(Enumerable.Repeat(0, 1000)).ToArray(), 500),
        };
    }

    private List<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<int[], int>.TestCase>();
        Random rand = new();

        int[] sizes = { 1, 10, 100, 1_000, 10_000, 50_000, 100_000 };

        foreach (int size in sizes)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rand.Next(0, 2);

            int expected = ComputeMaxAfterOneDeletion(array);
            testCases.Add(new(array, expected));
        }

        for (int t = 0; t < 10; t++)
        {
            int size = rand.Next(1, 100_001);
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rand.Next(0, 2);

            int expected = ComputeMaxAfterOneDeletion(array);
            testCases.Add(new(array, expected));
        }

        return testCases;
    }

    private static int ComputeMaxAfterOneDeletion(int[] nums)
    {
        int max = 0, left = 0, zeroCount = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
                zeroCount++;

            while (zeroCount > 1)
            {
                if (nums[left] == 0)
                    zeroCount--;
                left++;
            }

            max = Math.Max(max, right - left);
        }

        return max;
    }
}