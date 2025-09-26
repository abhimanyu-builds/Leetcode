using Leetcode.Common;
using Leetcode.Strategies.LongestHarmoniousSubsequence;

namespace Leetcode.StrategyRegistry
{
    public static class LongestHarmoniousSubsequenceStrategies
    {
        public static List<IProblemStrategy<int[], int>> All => new()
        {
            new ProblemStrategy<int[], int>("O(n) Frequency based", new OnFrequencyBasedSolution()),
            new ProblemStrategy<int[], int>("O(nlogn) Sort and Linear Scan", new OnlognSortScanSolution(),isInPlace:true),
        };
    }
}
