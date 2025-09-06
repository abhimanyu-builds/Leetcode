using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class TwoSumStrategies
    {
        public static List<IProblemStrategy<TwoSumInput, int[]>> All => new()
        {
            new ProblemStrategy<TwoSumInput, int[]>("O(n)", new TwoSumOnOneLoopDictionarySolution()),
            new ProblemStrategy<TwoSumInput, int[]>("O(n²)", new TwoSumOn2TwoLoopSolution())
        };
    }
}
