using Leetcode.Common;
using Leetcode.Models;
using Leetcode.TestHarness;

class Program
{
    static void Main()
    {
        RunProblem(ProblemType.TwoSumSorted);
    }
    static void RunProblem(ProblemType type)
    {
        switch (type)
        {
            case ProblemType.TwoSum:
                RunTestSuite<TwoSumInput, int[]>(
                    ProblemTestCaseFactory.GetTwoSumTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetTwoSumStrategies(),
                    CompareArrays
                );
                break;

            case ProblemType.TwoSumSorted:
                RunTestSuite<TwoSumSortedInput, int[]>(
                    ProblemTestCaseFactory.GetTwoSumSortedTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetTwoSumSortedStrategies(),
                    CompareArrays
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
    Func<TOutput, TOutput, bool> comparer)
    {
        foreach (var strategy in strategies)
        {
            Console.WriteLine($"\n Running strategy: {strategy.Name}");
            var testHarness = new ProblemTest<TInput, TOutput>(strategy.Implementation.Solve, comparer);
            testHarness.RunTests(testCases);
        }
    }
    static bool CompareArrays(int[] actual, int[] expected) =>
        actual.Length == expected.Length && actual[0] == expected[0] && actual[1] == expected[1];
}