using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class RemoveDuplicatesStrategies
    {
        public static List<IProblemStrategy<int[], int>> All => new()
        {
            new ProblemStrategy<int[], int>("O(n) - Two Pointer\r\n", new RemoveDuplicatesSortedTwoPointerSolution()),
            //new ProblemStrategy<int[], int>("HashSet", new RemoveDuplicatesSortedHashSetSolution()),
            //new ProblemStrategy<int[], int>("Stream Distinct", new RemoveDuplicatesSortedStreamDistinctSolution()),
            //new ProblemStrategy<int[], int>("Brute Force Shift", new RemoveDuplicatesSortedBruteForceShiftSolution())
        };
    }
}
