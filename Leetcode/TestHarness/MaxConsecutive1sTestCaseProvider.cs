using Leetcode.Interfaces;
using Leetcode.TestHarness;

public class MaxConsecutive1sTestCaseProvider : ITestCaseProvider<int[], int>
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
            new([1, 1, 0, 1, 1, 1], 3),
            new([1, 0, 1, 0, 1], 1),
            new([1, 1, 1, 1, 1], 5),
            new([0, 0, 0, 0], 0),
            new([1], 1),
            new([0], 0),
            new([1, 1, 0, 1, 1, 0, 1], 2),
            new([1, 0, 0, 0, 1, 1], 2),
            new([0, 0, 1, 1, 1, 0, 1], 3),
        };
    }

    private static List<ProblemTest<int[], int>.TestCase> GetEdgeCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
        {
            new([], 0),
            new([1], 1),
            new([0], 0),
            new([1, 1, 1, 1, 1, 1, 1], 7),
        };
    }
    private List<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<int[], int>.TestCase>();
        Random rand = new();

        // Generate a mix of small, medium, and large arrays
        int[] sizes = { 1, 10, 100, 1_000, 10_000, 50_000, 100_000 };

        foreach (int size in sizes)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rand.Next(0, 2); // binary values only

            int maxStreak = 0, current = 0;
            foreach (int bit in array)
            {
                current = bit == 1 ? current + 1 : 0;
                maxStreak = Math.Max(maxStreak, current);
            }

            testCases.Add(new(array, maxStreak));
        }

        // Add a few randomized sizes between 1 and 100_000
        for (int t = 0; t < 10; t++)
        {
            int size = rand.Next(1, 100_001);
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rand.Next(0, 2);

            int maxStreak = 0, current = 0;
            foreach (int bit in array)
            {
                current = bit == 1 ? current + 1 : 0;
                maxStreak = Math.Max(maxStreak, current);
            }

            testCases.Add(new(array, maxStreak));
        }

        return testCases;
    }
    private static List<ProblemTest<int[], int>.TestCase> GetContrastCases()
    {
        return new List<ProblemTest<int[], int>.TestCase>
    {
        // 🔹 Long streak at the start — both should perform equally
        new([1, 1, 1, 1, 1, 0, 0, 0], 5),

        // 🔹 Long streak at the end — manual method may do extra checks
        new([0, 0, 0, 1, 1, 1, 1, 1], 5),

        // 🔹 Multiple short streaks — streaming method shines
        new([1, 0, 1, 0, 1, 0, 1], 1),

        // 🔹 Dense zeroes with one long streak — manual method may skip faster
        new([0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0], 4),

        // 🔹 Alternating pattern — streaming avoids nested loops
        new([1, 0, 1, 0, 1, 0, 1, 0], 1),

        // 🔹 All ones — both should hit max immediately
        new([1, 1, 1, 1, 1, 1, 1, 1], 8),

        // 🔹 All zeroes — both should return 0
        new([0, 0, 0, 0, 0, 0], 0),

        // 🔹 Single one surrounded by zeroes — edge case
        new([0, 0, 1, 0, 0], 1),

        // 🔹 Empty array — both should return 0
        new([], 0),

        // 🔹 Large input with one long streak in the middle
        new(Enumerable.Repeat(0, 1000).Concat(Enumerable.Repeat(1, 500)).Concat(Enumerable.Repeat(0, 1000)).ToArray(), 500),
    };
    }
}