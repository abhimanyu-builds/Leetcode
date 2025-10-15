using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.JumpGameIV)]
public class JumpGameIVTestCaseProvider : ITestCaseProvider<int[], int>
{
    public List<ProblemTest<int[], int>.TestCase> GetTestCases()
    {
        // trivial, shortcut, and value-jump scenarios
        var cases = new List<ProblemTest<int[], int>.TestCase>()
        {
            Case([7]),                          // 0
            Case([1, 1]),                       // 1
            Case([1, 2]),                       // 1
            Case([1, 2, 3, 4, 1]),              // 2
            Case([1, 2, 3, 1, 5]),              // 3
            Case([1, 2, 1, 2, 1, 2, 1]),        // 2
            Case([100, -23, -23, 404, 100, 23, 23, 23, 3, 404]), // 3
            Case([7, 6, 9, 6, 9, 6, 9, 7]),     // 1
            Case([1, 2, 3, 4, 5]),              // 4
            Case([5, 4, 3, 2, 1]),              // 4
            Case([1, 1, 1, 1, 1]),              // 1
            Case([1, 2, 3, 4, 4, 4, 3, 2, 1]),  // 4
            Case([1_000_000_000, 2_000_000_000, 1_000_000_000]), // 1
        };
        //inject duplicate values to test jump logic
        cases.AddRange(GenerateRandomizedCases());
        //simulate plateaus, traps, and cycles
        cases.AddRange(GenerateAdversarialCases());

        return cases;
    }

    private static ProblemTest<int[], int>.TestCase Case(int[] arr) =>
        new(arr, MinSteps(arr));

    private static int MinSteps(int[] arr)
    {
        if (arr.Length <= 1) return 0;
        if (arr.Length == 2 || arr[0] == arr[^1]) return 1;

        var lookup = new Dictionary<int, List<int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (!lookup.TryAdd(arr[i], [i])) lookup[arr[i]].Add(i);
        }

        var visited = new HashSet<int>();
        var queue = new Queue<(int index, int steps)>();
        queue.Enqueue((0, 0));

        while (queue.TryDequeue(out var step))
        {
            int index = step.index;
            int steps = step.steps;
            if (index == arr.Length - 1) return steps;

            if (index + 1 < arr.Length && visited.Add(index + 1))
                queue.Enqueue((index + 1, steps + 1));

            if (index - 1 >= 0 && visited.Add(index - 1))
                queue.Enqueue((index - 1, steps + 1));

            if (lookup.TryGetValue(arr[index], out var indices))
            {
                foreach (int j in indices)
                {
                    if (j != index && visited.Add(j))
                        queue.Enqueue((j, steps + 1));
                }
                lookup.Remove(arr[index]);
            }
        }

        return -1;
    }

    private List<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        for (int i = 0; i < 5; i++)
        {
            int size = rand.Next(1000, 5000);
            var arr = new int[size];
            for (int j = 0; j < size; j++)
                arr[j] = rand.Next(-100_000_000, 100_000_001);

            // Inject some duplicate values to enable jumps
            for (int j = 0; j < size / 10; j++)
                arr[rand.Next(size)] = arr[0];

            cases.Add(Case(arr));
        }

        return cases;
    }

    private List<ProblemTest<int[], int>.TestCase> GenerateAdversarialCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<int[], int>.TestCase>();

        for (int i = 0; i < 5; i++)
        {
            int size = rand.Next(1000, 5000);
            var arr = new int[size];

            // Create plateaus and traps
            for (int j = 0; j < size; j++)
                arr[j] = j % 2 == 0 ? 1 : rand.Next(2, 5);

            // Inject a jumpable value at the end
            arr[^1] = arr[0];

            cases.Add(Case(arr));
        }

        return cases;
    }
}