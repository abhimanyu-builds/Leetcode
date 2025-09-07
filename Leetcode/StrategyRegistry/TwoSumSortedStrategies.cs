using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class TwoSumSortedStrategies
    {
        public static List<IProblemStrategy<TwoSumSortedInput, int[]>> All => new()
        {
            new ProblemStrategy<TwoSumSortedInput, int[]>("Two Sum Sorted O(n)", new TwoSumSortedSolution()),
            new ProblemStrategy<TwoSumSortedInput, int[]>("Two Sum Sorted Binary Search O(nlogn)", new TwoSumSortedBinarySearchSolution())
        };
    }
}
