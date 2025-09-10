using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class ThreeSumStrategies
    {
        public static List<IProblemStrategy<ThreeSumInput, List<int[]>>> All => new()
        {
            new ProblemStrategy<ThreeSumInput, List <int[]>>("O(n^2)", new ThreeSum0On2OneLoopDictionarySolution()),
        };
    }
}
