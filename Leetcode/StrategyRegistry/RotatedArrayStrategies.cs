using Leetcode.Common;
using Leetcode.Models;
using RA = Leetcode.Strategies.RotatedArray;
using RAII = Leetcode.Strategies.RotatedArrayII;

namespace Leetcode.StrategyRegistry
{
    public static class RotatedArrayStrategies
    {
        public static List<IProblemStrategy<RotatedArrayInput, int>> All => new()
        {
            new ProblemStrategy<RotatedArrayInput, int>("O(n) - Brute force linear search\r\n", new RA.OnBruteForceSolution()),
            new ProblemStrategy<RotatedArrayInput, int>("O(logn) - Two Pointer Binary search solution\r\n", new RA.OlognTwoPointerSolution()),
            new ProblemStrategy<RotatedArrayInput, int>("O(n) - Brute force linear search with duplicates\r\n", new RAII.OnBruteForceSolution(), hasDuplicates:true),
            new ProblemStrategy<RotatedArrayInput, int>("O(logn) - Two Pointer Binary search solution with duplicates\r\n", new RAII.OlognTwoPointerSolution(), hasDuplicates:true),
        };
    }
}
