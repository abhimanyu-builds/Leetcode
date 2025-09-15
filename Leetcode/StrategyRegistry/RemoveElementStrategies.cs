using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class RemoveElementStrategies
    {
        public static List<IProblemStrategy<RemoveElementInput, int>> All => new()
        {
            new ProblemStrategy<RemoveElementInput, int>("O(n) - Fwd Pointer Overwrite\r\n", new RemoveElementFwdPointerOverwriteSolution(), isInPlace:true),
            new ProblemStrategy<RemoveElementInput, int>("O(n) - Two Pointer Partitioning\r\n", new RemoveElementTwoPointerPartitioningSolution(), isInPlace:true),
            new ProblemStrategy<RemoveElementInput, int>("O(n) - Two Pointer Swap\r\n", new RemoveElementSwapWithEndPointerSolution(), isInPlace:true),
        };
    }
}
