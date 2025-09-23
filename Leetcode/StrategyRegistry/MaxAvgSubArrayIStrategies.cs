using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.MaxAvgSubArrayI;

namespace Leetcode.StrategyRegistry
{
    public static class MaxAvgSubArrayIStrategies
    {
        public static List<IProblemStrategy<MaxAvgSubArrayInput, double>> All => new()
        {
            new ProblemStrategy<MaxAvgSubArrayInput, double>("O(nk) Brute force", new OnkBruteForceSolution()),
            new ProblemStrategy<MaxAvgSubArrayInput, double>("O(n) Sliding Window", new OnSlidingWindowSolution()),
        };
    }
}
