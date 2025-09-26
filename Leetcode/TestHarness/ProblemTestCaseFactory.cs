using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.TestHarness
{
    public static class ProblemTestCaseFactory
    {
        public static ITestCaseProvider<TwoSumInput, int[]> GetTwoSumTestCases() => new TwoSumTestCaseProvider();
        public static ITestCaseProvider<TwoSumSortedInput, int[]> GetTwoSumSortedTestCases() => new TwoSumSortedTestCaseProvider();
        public static ITestCaseProvider<ThreeSumInput, List<List<int>>> GetThreeSumTestCases() => new ThreeSumTestCaseProvider();
        public static ITestCaseProvider<int[], int> GetRemoveDuplicatesTestCases() => new RemoveDuplicatesSortedTestCaseProvider();
        public static ITestCaseProvider<RemoveElementInput, int> GetRemoveElementTestCases() => new RemoveElementTestCaseProvider();
        public static ITestCaseProvider<RotatedArrayInput, int> GetRotatedArrayTestCases() => new RotatedArrayTestCaseProvider();
        public static ITestCaseProvider<ContainsDuplicateInput, bool> GetContainsDuplicateITestCases() => new ContainsDuplicateITestCaseProvider();
        public static ITestCaseProvider<ContainsDuplicateInput, bool> GetContainsDuplicateIITestCases() => new ContainsDuplicateIITestCaseProvider();
        public static ITestCaseProvider<MaxAvgSubArrayInput, double> GetMaxAvgSubArrayITestCases() => new MaxAvgSubArrayITestCaseProvider();
        public static ITestCaseProvider<int[], int> GetMaxConsecutive1sTestCases() => new MaxConsecutive1sTestCaseProvider();
        public static ITestCaseProvider<SearchInsertPositionInput, int> GetSearchInsertPositionTestCases() => new SearchInsertPositionTestCaseProvider();
        public static ITestCaseProvider<int[], int> GetLongestHarmoniousSubsequenceTestCases() => new LongestHarmoniousSubsequenceTestCaseProvider();

    }
}
