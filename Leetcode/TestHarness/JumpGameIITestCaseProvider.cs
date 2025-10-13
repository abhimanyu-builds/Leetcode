using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.JumpGameII)]
public class JumpGameIITestCaseProvider : ITestCaseProvider<int[], int>
{
    public List<ProblemTest<int[], int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], int>.TestCase>
        {
            Case([2, 3, 1, 1, 4]),     // 2
            Case([2, 3, 0, 1, 4]),     // 2
            Case([1]),                // 0
            Case([1, 1]),             // 1
            Case([2, 1]),             // 1
            Case([1, 2, 3, 4, 5]),     // 3
            Case([5, 4, 3, 2, 1]),     // 1
            Case([1, 2, 2, 1]),        // 2
            Case([1, 3, 2]),           // 1
            Case([3, 5, 5]),           // 1
            Case([2, 5, 0, 0]),        // 2
            Case([1000, 5, 0, 0]),     // 1
            Case([2, 2, 1, 0, 4]),     // 3
            Case([4, 1, 1, 0, 2, 0]),  // 2
            Case([2, 3, 1, 0, 0, 4]),  // 3
            Case([5, 1, 1, 1, 0, 0, 1]), // 3
            Case([2, 0, 2, 0, 0]),     // 3
            Case([3, 2, 1, 0, 0, 0, 1]), // 4
            Case([4, 0, 0, 0, 0, 1]),  // 2
            Case([2, 2, 0, 0, 1]),     // 3
        };

        cases.AddRange(GenerateReachAwareFuzzCases());
        cases.AddRange(GenerateAdversarialFuzzCases());

        return cases;
    }

    private static ProblemTest<int[], int>.TestCase Case(int[] nums) =>
        new(nums, MinJumps(nums));

    private static int MinJumps(int[] nums)
    {
        int jumps = 0, end = 0, farthest = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (i == end)
            {
                jumps++;
                end = farthest;
            }
        }
        return jumps;
    }

    private List<ProblemTest<int[], int>.TestCase> GenerateReachAwareFuzzCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        foreach (JumpDistribution dist in Enum.GetValues(typeof(JumpDistribution)))
        {
            for (int i = 0; i < 5; i++)
            {
                int size = rand.Next(1, 10_001);
                var nums = new int[size];

                switch (dist)
                {
                    case JumpDistribution.FrontLoaded:
                        for (int j = 0; j < size; j++)
                            nums[j] = j < size / 3 ? rand.Next(10_000, 100_001) : rand.Next(0, 10);
                        break;

                    case JumpDistribution.MidLoaded:
                        for (int j = 0; j < size; j++)
                            nums[j] = (j > size / 3 && j < 2 * size / 3) ? rand.Next(10_000, 100_001) : rand.Next(0, 10);
                        break;

                    case JumpDistribution.TailLoaded:
                        for (int j = 0; j < size; j++)
                            nums[j] = j > 2 * size / 3 ? rand.Next(10_000, 100_001) : rand.Next(0, 10);
                        break;

                    case JumpDistribution.UniformRandom:
                        for (int j = 0; j < size; j++)
                            nums[j] = rand.Next(0, 100_001);
                        break;
                }

                cases.Add(Case(nums));
            }
        }

        return cases;
    }

    private List<ProblemTest<int[], int>.TestCase> GenerateAdversarialFuzzCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        var fuzz = new[]
        {
            [1, 2, 3, 3, 2, 1],
            [5, 4, 3, 2, 1],
            [1, 2, 3, 4, 5],
            [1, 3, 2, 4, 3],
            [3, 2, 1, 2, 3],
            [7, 7, 7, 7, 7],
            [1, 3, 2, 4, 3, 5],
            [1, 2, 2, 2, 3, 2, 1],
            [1, 2, 3, 4, 4, 4, 3, 2, 1],
            new[] {1_000_000_000, 2_000_000_000, 1_000_000_000}
        };

        for (int i = 0; i < 5; i++)
        {
            int size = rand.Next(20, 100);
            int plateauStart = rand.Next(5, size / 2);
            int plateauLength = rand.Next(3, size / 4);
            int plateauEnd = Math.Min(size - 1, plateauStart + plateauLength);

            var plateau = new int[size];
            for (int j = 0; j < size; j++)
                plateau[j] = rand.Next(1, 3);

            for (int j = plateauStart; j < plateauEnd; j++)
                plateau[j] = 1;

            plateau[plateauEnd] = rand.Next(plateauLength + 1, plateauLength + 5);

            cases.Add(Case(plateau));
        }

        cases.AddRange(fuzz.Select(Case).ToList());

        return cases;
    }
}