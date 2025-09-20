using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.TwoSumSorted;

namespace Leetcode.StrategyRegistry
{
    public static class TwoSumSortedStrategies
    {
        public static List<IProblemStrategy<TwoSumSortedInput, int[]>> All => new()
        {
            new ProblemStrategy<TwoSumSortedInput, int[]>("O(n) Two Pointer", new TwoPointerSolution()),
            new ProblemStrategy<TwoSumSortedInput, int[]>("O(nlogn) Binary Search", new BinarySearchSolution())
        };
    }
}
