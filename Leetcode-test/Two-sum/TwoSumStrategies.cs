using Leetcode_test.Common;
using Leetcode_test.Models;
using Leetcode_test.Strategies;

namespace Leetcode_test.Two_sum
{
    public static class TwoSumStrategies
    {
        public static List<IProblemStrategy<TwoSumInput, int[]>> All => new()
        {
            new ProblemStrategy<TwoSumInput, int[]>("O(n)", new OnOneLoopDictionarySolution()),
            new ProblemStrategy<TwoSumInput, int[]>("O(n²)", new On2TwoLoopSolution())
        };
    }
}
