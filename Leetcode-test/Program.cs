using Leetcode_test.Common;
using Leetcode_test.Models;
using Leetcode_test.TestHarness;

class Program
{
    static void Main()
    {
        var testCases = ProblemTestCaseFactory.GetTwoSumTestCases().GetTestCases();

        foreach (var strategy in ProblemStrategyFactory.GetTwoSumStrategies())
        {
            Console.WriteLine($"Running strategy: {strategy.Name}");
            var testHarness = new ProblemTest<TwoSumInput, int[]>(strategy.Implementation.Solve, CompareArrays);
            testHarness.RunTests(testCases);
        }
    }

    static bool CompareArrays(int[] actual, int[] expected) =>
        actual.Length == expected.Length && actual[0] == expected[0] && actual[1] == expected[1];
}