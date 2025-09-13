using Leetcode.Common;
using Leetcode.Models;
using Leetcode.TestHarness;

class Program
{
    static void Main()
    {
        RunProblem(ProblemType.TwoSum);
        RunProblem(ProblemType.TwoSumSorted);
        RunProblem(ProblemType.ThreeSum);
    }
    static void RunProblem(ProblemType type, int iterations = 1)
    {
        switch (type)
        {
            case ProblemType.TwoSum:
                RunTestSuite<TwoSumInput, int[]>(
                    ProblemTestCaseFactory.GetTwoSumTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetTwoSumStrategies(),
                    CompareArrays, iterations
                );
                break;

            case ProblemType.TwoSumSorted:
                RunTestSuite<TwoSumSortedInput, int[]>(
                    ProblemTestCaseFactory.GetTwoSumSortedTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetTwoSumSortedStrategies(),
                    CompareArrays, iterations
                );
                break;

            case ProblemType.ThreeSum:
                RunTestSuite<ThreeSumInput, List<List<int>>>(
                    ProblemTestCaseFactory.GetThreeSumTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetThreeSumStrategies(),
                    CompareTripletSets, iterations
                );
                break;

            default:
                Console.WriteLine($"Unsupported problem type {type}");
                break;
        }
    }
    static void RunTestSuite<TInput, TOutput>(
    List<ProblemTest<TInput, TOutput>.TestCase> testCases,
    IEnumerable<IProblemStrategy<TInput, TOutput>> strategies,
    Func<TOutput, TOutput, bool> comparer,
    int iterations)
    {
        foreach (var strategy in strategies)
        {
            Console.WriteLine($"Running strategy: {strategy.Name} (x{iterations} iterations per test)");
            var testHarness = new ProblemTest<TInput, TOutput>(strategy.Implementation.Solve, comparer);
            testHarness.RunTests(testCases, iterations);
        }
    }
    static bool CompareArrays(int[] actual, int[] expected)
    {
        if (actual == null || expected == null) return false;
        if (actual.Length != expected.Length) return false;
        return actual.SequenceEqual(expected);
    }
    static bool CompareTripletSets(List<List<int>> actual, List<List<int>> expected)
    {
        if (actual == null || expected == null) return false;
        if (actual.Count == 0 && actual.Count == expected.Count) return true;
        if (actual.Count != expected.Count) return false;

        var actualSorted = actual.Select(t => t.OrderBy(x => x).ToArray()).ToList();
        var expectedSorted = expected.Select(t => t.OrderBy(x => x).ToArray()).ToList();

        var actualSet = new HashSet<string>(actualSorted.Select(t => string.Join(",", t)));
        var expectedSet = new HashSet<string>(expectedSorted.Select(t => string.Join(",", t)));

        return actualSet.SetEquals(expectedSet);
    }
}