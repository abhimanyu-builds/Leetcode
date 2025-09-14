using Leetcode.Common;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class RemoveDuplicatesStrategies
    {
        public static List<IProblemStrategy<int[], int>> All => new()
        {
            new ProblemStrategy<int[], int>("O(n) - Two Pointer\r\n", new RemoveDuplicatesSortedTwoPointerSolution(), isInPlace:true),
            new ProblemStrategy<int[], int>("O(n) - Two Pointer Allow Upto N times\r\n", new RemoveDuplicatesAllowNTimesSortedTwoPointerSolution(), isInPlace:true),
        };
    }
}
