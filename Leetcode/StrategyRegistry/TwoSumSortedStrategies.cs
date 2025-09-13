using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class TwoSumSortedStrategies
    {
        public static List<IProblemStrategy<TwoSumSortedInput, int[]>> All => new()
        {
            new ProblemStrategy<TwoSumSortedInput, int[]>("O(n) Two Pointer", new TwoSumSortedTwoPointerSolution()),
            new ProblemStrategy<TwoSumSortedInput, int[]>("O(nlogn) Binary Search", new TwoSumSortedBinarySearchSolution())
        };
    }
}
