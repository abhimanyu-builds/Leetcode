using Leetcode.Common;
using Leetcode.Strategies.MaxConsecutive1s;

namespace Leetcode.StrategyRegistry
{
    public static class MaxConsecutive1sStrategies
    {
        public static List<IProblemStrategy<int[], int>> All => new()
        {
            new ProblemStrategy<int[], int>("O(n) Manual index manipulation", new OnManualIndexManipulationScanSolution()),
            new ProblemStrategy<int[], int>("O(n) Stateful Traversal", new OnStatefulTraversalScanSolution()),
        };
    }
}
