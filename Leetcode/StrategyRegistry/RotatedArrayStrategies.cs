using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class RotatedArrayStrategies
    {
        public static List<IProblemStrategy<RotatedArrayInput, int>> All => new()
        {
            new ProblemStrategy<RotatedArrayInput, int>("O(n) - Brute force linear search\r\n", new RotatedArrayOnBruteForceSolution()),
            new ProblemStrategy<RotatedArrayInput, int>("O(logn) - Two Pointer Binary search solution\r\n", new RotatedArrayOlognTwoPointerSolution()),
        };
    }
}
