using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.TestHarness
{
    public static class ProblemTestCaseFactory
    {
        public static ITestCaseProvider<TwoSumInput, int[]> GetTwoSumTestCases() =>
            new TwoSumTestCaseProvider();
        public static ITestCaseProvider<TwoSumSortedInput, int[]> GetTwoSumSortedTestCases() =>
            new TwoSumSortedTestCaseProvider();
        public static ITestCaseProvider<ThreeSumInput, List<List<int>>> GetThreeSumTestCases() =>
            new ThreeSumTestCaseProvider();
        public static ITestCaseProvider<int[], int> GetRemoveDuplicatesTestCases() =>
            new RemoveDuplicatesSortedTestCaseProvider();
    }
}
