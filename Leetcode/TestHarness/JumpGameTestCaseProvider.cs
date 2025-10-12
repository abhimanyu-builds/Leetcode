using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.JumpGame)]
public class JumpGameTestCaseProvider : ITestCaseProvider<int[], bool>
{
    public List<ProblemTest<int[], bool>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<int[], bool>.TestCase>
        {
            Case([1, 2, 3, 2, 1]),
            Case([1, 2, 3, 4]),
            Case([1]),
            Case([1, 1]),
            Case([2, 1]),
            Case([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]),
            Case([10, 9, 8, 7, 6, 5, 4, 3, 2, 1]),
            Case([1, 2, 2, 1]),
            Case([1, 3, 2]),
            Case([0, 3, 2, 1]),       // stuck at index 0
            Case([1, 2, 3, 2, 2]),
            Case([3, 5, 5]),
            Case([1, 2, 3, 4, 3, 2, 1]),
            Case([3, 2, 1, 0, 4]),    // all paths funnel into index 3 (value 0)
            Case([2, 0, 0]),
            Case([1, 0, 1, 0]),       // stuck at index 2
            Case([2, 5, 0, 0]),
            Case([1000, 5, 0, 0]),
            Case([2, 2, 1, 0, 4]),    // maxReach stalls at index 3
            Case([4, 1, 1, 0, 2, 0]), // all paths land on index 3 (value 0)
            Case([3, 1, 0, 0, 1]),    // index 2 is reachable, but index 3 is not
            Case([2, 3, 1, 0, 0, 4]), // index 3 is unavoidable
            Case([5, 1, 1, 1, 0, 0, 1]), // maxReach = 4, stuck at 5
            Case([1, 1, 1, 0, 1]),    // maxReach = 3, index 4 unreachable
            Case([2, 0, 2, 0, 0]),    // index 3 is a trap
            Case([3, 2, 1, 0, 0, 0, 1]), // all paths stall before index 6
            Case([4, 0, 0, 0, 0, 1]), // maxReach = 4, but index 5 unreachable
            Case([2, 2, 0, 0, 1]),    // index 3 is a wall
            // Guaranteed traps: all paths lead to a dead zone
            Case([3, 2, 1, 0, 4]),
            Case([2, 2, 1, 0, 4]),
            Case([4, 1, 1, 0, 2, 0]),
            Case([3, 1, 0, 0, 1]),
            Case([2, 3, 1, 0, 0, 4]),
            Case([5, 1, 1, 1, 0, 0, 1]),
            Case([1, 1, 1, 0, 1]),
            Case([2, 0, 2, 0, 0]),
            Case([3, 2, 1, 0, 0, 0, 1]),
            Case([4, 0, 0, 0, 0, 1]),
            Case([2, 2, 0, 0, 1]),
        };

        cases.AddRange(GenerateReachAwareFuzzCases());
        cases.AddRange(GenerateAdversarialFuzzCases());

        return cases;
    }

    private static ProblemTest<int[], bool>.TestCase Case(int[] nums) =>
        new(nums, IsReachable(nums));

    private static bool IsReachable(int[] nums)
    {
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);
            if (maxReach >= nums.Length - 1) return true;
        }
        return true;
    }
    private List<ProblemTest<int[], bool>.TestCase> GenerateReachAwareFuzzCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], bool>.TestCase>();

        foreach (JumpDistribution dist in Enum.GetValues(typeof(JumpDistribution)))
        {
            for (int i = 0; i < 5; i++)
            {
                int size = rand.Next(1, 10_001); // constraint: 1 <= nums.length <= 10_000
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
                            nums[j] = rand.Next(0, 100_001); // constraint: 0 <= nums[i] <= 100_000
                        break;
                }

                cases.Add(Case(nums));
            }
        }

        return cases;
    }
    private List<ProblemTest<int[], bool>.TestCase> GenerateAdversarialFuzzCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], bool>.TestCase>();

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
        // Plateau-aware variants
        for (int i = 0; i < 5; i++)
        {
            int size = rand.Next(20, 100);
            int plateauStart = rand.Next(5, size / 2);
            int plateauLength = rand.Next(3, size / 4);
            int plateauEnd = Math.Min(size - 1, plateauStart + plateauLength);

            var plateau = new int[size];

            // Fill with low jumps
            for (int j = 0; j < size; j++)
                plateau[j] = rand.Next(1, 3);

            // Inject plateau
            for (int j = plateauStart; j < plateauEnd; j++)
                plateau[j] = 1;

            // Toggle: reachable or not
            bool reachable = rand.NextDouble() < 0.5;

            if (!reachable)
            {
                // Insert a guaranteed trap at the end of the plateau
                if (plateauEnd < size)
                    plateau[plateauEnd] = 0;
            }
            else
            {
                // Ensure escape from plateau
                if (plateauEnd < size)
                    plateau[plateauEnd] = rand.Next(plateauLength + 1, plateauLength + 5);
            }

            cases.Add(Case(plateau));
        }
        cases.AddRange(fuzz.Select(Case).ToList());

        return cases;
    }
}