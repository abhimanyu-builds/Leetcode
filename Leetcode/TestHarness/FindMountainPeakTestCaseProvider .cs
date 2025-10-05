using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.FindMountainPeak)]
public class FindMountainPeakTestCaseProvider : ITestCaseProvider<int[], int>
{
    public List<ProblemTest<int[], int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], int>.TestCase>
        {
            new([1, 2, 3, 2, 1], 2),
            new([1, 3, 2], 1),
            new([0, 3, 2, 1], 1),
            new([1, 2, 3, 4, 3, 2, 1], 3),
            new([0, 1, 2, 3, 4, 5, 3, 2, 1], 5),
            new([0, 2, 4, 6, 8, 10, 9, 7, 5, 3, 1], 5),
            new([1, 5, 10, 20, 15, 10, 5], 3),
            new([1, 2, 3, 5, 4, 2], 3),
            new([0, 1, 0], 1),
        };

        cases.AddRange(GenerateRandomizedCases());

        return cases;
    }

    private List<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        foreach (PivotDepth depth in Enum.GetValues(typeof(PivotDepth)))
        {
            for (int i = 0; i < 5; i++)
            {
                int size = rand.Next(3, 100_001); // 3 to 100_000 inclusive

                int peakIndex = depth switch
                {
                    PivotDepth.Shallow => rand.Next(1, Math.Max(2, size / 4)),
                    PivotDepth.Medium => rand.Next(size / 3, 2 * size / 3),
                    PivotDepth.Deep => rand.Next(Math.Max(size - size / 4, 2), size - 1),
                    _ => rand.Next(1, size - 1)
                };

                var leftSet = new HashSet<int>();
                while (leftSet.Count < peakIndex)
                    leftSet.Add(rand.Next(0, 1_000_000));

                var left = leftSet.OrderBy(x => x).ToList();

                int rightSize = size - peakIndex - 1;
                var rightSet = new HashSet<int>();
                while (rightSet.Count < rightSize)
                    rightSet.Add(rand.Next(0, 1_000_000));

                var right = rightSet.OrderByDescending(x => x).ToList();

                int peakValue = Math.Max(left.Last(), right.First()) + 1;
                if (peakValue > 1_000_000) peakValue = 1_000_000;

                var mountain = left.Concat(new[] { peakValue }).Concat(right).ToArray();
                cases.Add(new(mountain, peakIndex));
            }
        }

        return cases;
    }
}