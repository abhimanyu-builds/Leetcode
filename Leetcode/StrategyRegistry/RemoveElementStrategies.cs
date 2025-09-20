using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.RemoveElement;

namespace Leetcode.StrategyRegistry
{
    public static class RemoveElementStrategies
    {
        public static List<IProblemStrategy<RemoveElementInput, int>> All => new()
        {
            new ProblemStrategy<RemoveElementInput, int>("O(n) - Fwd Pointer Overwrite\r\n", new FwdPointerOverwriteSolution(), isInPlace:true),
            new ProblemStrategy<RemoveElementInput, int>("O(n) - Two Pointer Partitioning\r\n", new TwoPointerPartitioningSolution(), isInPlace:true),
            new ProblemStrategy<RemoveElementInput, int>("O(n) - Two Pointer Swap\r\n", new SwapWithEndPointerSolution(), isInPlace:true),
        };
    }
}
