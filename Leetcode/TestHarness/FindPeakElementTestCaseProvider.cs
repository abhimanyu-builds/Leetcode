using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.FindPeakElement)]
public class FindPeakElementTestCaseProvider : ITestCaseProvider<int[], int>
{
    public List<ProblemTest<int[], int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], int>.TestCase>
        {
            // Static edge cases
            new([], -1), // Invalid array
            new([42], 0), // Single element
            new([1, 0], 0), // First is peak
            new([0, 1], 1), // Last is peak
            new([1, 2, 3, 2, 1], 2), // Peak in middle
            new([1, 2, 3, 1], 2), // Peak in middle
            new([1, 3, 2], 1), // Classic peak
            new([0, 3, 2, 1], 1), // Peak near start
            new([1, 2, 3, 4, 3, 2, 1], 3), // Symmetric mountain
            new([0, 1, 2, 3, 4, 5, 3, 2, 1], 5), // Peak near end
            new([0, 2, 4, 6, 8, 10, 9, 7, 5, 3, 1], 5), // Long slope
            new([1, 5, 10, 20, 15, 10, 5], 3), // Steep peak
            new([1, 2, 3, 5, 4, 2], 3), // Ascend then descend
            new([0, 1, 0], 1), // Simple peak
            new([int.MinValue, -1, int.MinValue], 1), // Near lower bound
            new([int.MaxValue - 2, int.MaxValue - 1, int.MaxValue], 2), // Near upper bound
            new([1, 3, 2, 4, 3, 5, 4], 5), // Multiple peaks
            new([1, 2, 1, 3, 5, 6, 4], 5), // Multiple peaks
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
                int size = rand.Next(10, 1001); // Respect Leetcode constraint: max 1000

                int peakIndex = depth switch
                {
                    PivotDepth.Shallow => rand.Next(1, Math.Max(2, size / 4)),
                    PivotDepth.Medium => rand.Next(size / 3, 2 * size / 3),
                    PivotDepth.Deep => rand.Next(Math.Max(size - size / 4, 2), size - 1),
                    _ => rand.Next(1, size - 1)
                };

                var leftSet = new HashSet<int>();
                while (leftSet.Count < peakIndex)
                    leftSet.Add(rand.Next(-2_000_000_000, 2_000_000_000));

                var left = leftSet.OrderBy(x => x).ToList();

                int rightSize = size - peakIndex - 1;
                var rightSet = new HashSet<int>();
                while (rightSet.Count < rightSize)
                    rightSet.Add(rand.Next(-2_000_000_000, 2_000_000_000));

                var right = rightSet.OrderByDescending(x => x).ToList();

                int peakValue = Math.Max(left.Last(), right.First()) + 1;
                if (peakValue > int.MaxValue) peakValue = int.MaxValue;

                var mountain = left.Concat(new[] { peakValue }).Concat(right).ToArray();
                cases.Add(new(mountain, peakIndex));
            }
        }

        return cases;
    }
}