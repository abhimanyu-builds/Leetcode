using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.ValidMountainArray)]
public class ValidMountainArrayTestCaseProvider : ITestCaseProvider<int[], bool>
{
    public List<ProblemTest<int[], bool>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], bool>.TestCase>
        {
            new([1, 2, 3, 2, 1], true),
            new([1, 2, 3, 4], false),
            new([1], false),
            new([1, 1], false),
            new([2, 1], false),
            new([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], false),
            new([10, 9, 8, 7, 6, 5, 4, 3, 2, 1], false),
            new([1, 2, 2, 1], false),
            new([1, 3, 2], true),
            new([0, 3, 2,1], true),
            new([1, 2, 3, 2, 2], false),
            new([3, 5, 5], false),
            new([1, 2, 3, 4, 3, 2, 1], true),
        };

        cases.AddRange(GenerateRandomizedCases());
        cases.AddRange(GenerateAdversarialFuzzCases());

        return cases;
    }
    private List<ProblemTest<int[], bool>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], bool>.TestCase>();

        foreach (PivotDepth depth in Enum.GetValues(typeof(PivotDepth)))
        {
            for (int i = 0; i < 5; i++) // 5 cases per depth variant
            {
                int size = rand.Next(10, 1000);
                if (depth == PivotDepth.None)
                {
                    // Fully sorted → invalid mountain
                    var sorted = Enumerable.Range(0, size).Select(_ => rand.Next()).OrderBy(x => x).ToArray();
                    cases.Add(new(sorted, false));
                    continue;
                }

                int peak = depth switch
                {
                    PivotDepth.Shallow => rand.Next(1, Math.Max(2, size / 4)),
                    PivotDepth.Medium => rand.Next(size / 3, 2 * size / 3),
                    PivotDepth.Deep => rand.Next(Math.Max(size - size / 4, 2), size - 1),
                    _ => rand.Next(1, size - 1)
                };

                // Generate unique ascending values
                var left = Enumerable.Range(0, peak)
                    .Select(_ => rand.Next())
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                // Ensure we have enough unique values
                while (left.Count < peak)
                {
                    left.Add(rand.Next());
                    left = left.Distinct().OrderBy(x => x).ToList();
                }

                // Generate unique descending values
                var right = Enumerable.Range(0, size - peak)
                    .Select(_ => rand.Next())
                    .Distinct()
                    .OrderByDescending(x => x)
                    .ToList();

                while (right.Count < size - peak)
                {
                    right.Add(rand.Next());
                    right = right.Distinct().OrderByDescending(x => x).ToList();
                }

                // Ensure peak continuity
                if (left.Count > 0 && right.Count > 0 && left.Last() >= right.First())
                {
                    int bump = left.Last() + rand.Next(1, 10);
                    right = right.Select(x => x < bump ? x : bump - 1).ToList();
                }

                var mountain = left.Concat(right).ToArray();
                cases.Add(new(mountain, true));
            }
        }

        return cases;
    }

    private List<ProblemTest<int[], bool>.TestCase> GenerateAdversarialFuzzCases()
    {
        var cases = new List<ProblemTest<int[], bool>.TestCase>
        {
            new([1, 2, 3, 3, 2, 1], false), // Plateau at peak
            new([5, 4, 3, 2, 1], false), // Peak at start
            new([1, 2, 3, 4, 5], false), // Peak at end
            new([1, 3, 2, 4, 3], false), // Multiple peaks
            new([3, 2, 1, 2, 3], false), // Valley instead of mountain
            new([7, 7, 7, 7, 7], false), // All equal
            new([1, 3, 2, 4, 3, 5], false), // Zigzag pattern
            new([1, 2, 2, 2, 3, 2, 1], false), // Long plateau mid-ascent
            new([1, 2, 3, 4, 4, 4, 3, 2, 1], false), // Long plateau mid-descent
            new([1_000_000_000, 2_000_000_000, 1_000_000_000], true) // Valid mountain with large values
        };

        return cases;
    }
}