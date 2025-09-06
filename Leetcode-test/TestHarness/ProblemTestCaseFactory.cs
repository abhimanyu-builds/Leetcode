using Leetcode_test.Interfaces;
using Leetcode_test.Models;

namespace Leetcode_test.TestHarness
{
    public static class ProblemTestCaseFactory
    {
        public static ITestCaseProvider<TwoSumInput, int[]> GetTwoSumTestCases() =>
            new TwoSumTestCaseProvider();
    }
}
