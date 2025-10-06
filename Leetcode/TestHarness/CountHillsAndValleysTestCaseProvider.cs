using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.HillAndValleyCount)]
public class CountHillsAndValleysTestCaseProvider : ITestCaseProvider<int[], int>
{
    public List<ProblemTest<int[], int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        // Static edge cases
        var edgeCases = new[]
        {
            [], // empty
            [42],
            [1, 0],
            [0, 1],
            [6, 6, 5, 5, 4, 1],
            [1, 1, 2, 2, 2, 3, 4, 5, 5, 6],
            [1, 2, 3, 2, 1],
            [1, 2, 3, 1],
            [1, 3, 2],
            [0, 3, 2, 1],
            [1, 2, 3, 4, 3, 2, 1],
            [0, 1, 2, 3, 4, 5, 3, 2, 1],
            [0, 2, 4, 6, 8, 10, 9, 7, 5, 3, 1],
            [1, 5, 10, 20, 15, 10, 5],
            [1, 2, 3, 5, 4, 2],
            [0, 1, 0],
            [int.MinValue, -1, int.MinValue],
            [int.MaxValue - 2, int.MaxValue - 1, int.MaxValue],
            [1, 3, 2, 4, 3, 5, 4],
            [1, 2, 1, 3, 5, 6, 4],
            [57,57,57,57,57,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,85,85,85,86,86,86],
            new[] { 2, 4, 1, 1, 6, 5 },
        };

        foreach (var input in edgeCases)
            cases.Add(new(input, Count(input)));

        // Plateau edge cases
        var plateauCases = new[]
        {
            [1, 3, 3, 3, 2],
            [5, 4, 4, 4, 6],
            [1, 2, 2, 2, 3],
            [1, 2, 2, 2, 1],
            [1, 2, 2, 2, 3, 2, 2, 2, 1],
            [1, 1, 1, 1],
            [1, 2, 2, 2, 2, 1],
            new[] { 1, 3, 3, 3, 3, 3, 2 },
        };

        foreach (var input in plateauCases)
            cases.Add(new(input, Count(input)));

        cases.AddRange(GenerateRandomizedCases());
        cases.AddRange(GeneratePlateauAwareCases());

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
                int size = rand.Next(10, 1001);
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
                cases.Add(new(mountain, Count(mountain)));
            }
        }

        return cases;
    }

    private List<ProblemTest<int[], int>.TestCase> GeneratePlateauAwareCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        for (int i = 0; i < 10; i++)
        {
            int left = rand.Next(1, 50);
            int plateau = rand.Next(51, 100);
            int right = rand.Next(1, 50);

            var leftSlope = Enumerable.Range(1, rand.Next(2, 5)).Select(x => left + x).ToList();
            var rightSlope = Enumerable.Range(1, rand.Next(2, 5)).Select(x => plateau - x).ToList();
            var plateauWidth = rand.Next(2, 6);
            var plateauValues = Enumerable.Repeat(plateau, plateauWidth).ToList();

            var hill = leftSlope.Concat(plateauValues).Concat(rightSlope).ToArray();
            cases.Add(new(hill, Count(hill)));

            leftSlope = Enumerable.Range(1, rand.Next(2, 5)).Select(x => left - x).ToList();
            rightSlope = Enumerable.Range(1, rand.Next(2, 5)).Select(x => plateau + x).ToList();
            plateauValues = Enumerable.Repeat(plateau, plateauWidth).ToList();

            var valley = leftSlope.Concat(plateauValues).Concat(rightSlope).ToArray();
            cases.Add(new(valley, Count(valley)));
        }

        return cases;
    }

    private int Count(int[] nums)
    {
        var compressed = new List<int>();
        foreach (var num in nums)
        {
            if (compressed.Count == 0 || compressed[^1] != num)
                compressed.Add(num);
        }

        int count = 0;
        for (int i = 1; i < compressed.Count - 1; i++)
        {
            if (compressed[i] > compressed[i - 1] && compressed[i] > compressed[i + 1])
                count++;
            else if (compressed[i] < compressed[i - 1] && compressed[i] < compressed[i + 1])
                count++;
        }
        return count;
    }
}