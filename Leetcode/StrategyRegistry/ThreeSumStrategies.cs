using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.ThreeSum;

namespace Leetcode.StrategyRegistry
{
    public static class ThreeSumStrategies
    {
        public static List<IProblemStrategy<ThreeSumInput, List<List<int>>>> All => new()
        {
            new ProblemStrategy<ThreeSumInput, List<List<int>>>("O(n^2) - Dictionary-based frequency analysis\r\n", new On2OneLoopDictionarySolution()),
            new ProblemStrategy<ThreeSumInput, List<List<int>>>("O(n^2) - Sorting + Two-pointer\r\n", new On2SortingTwoPointerSolution()),
            new ProblemStrategy<ThreeSumInput, List<List<int>>>("O(n^2) - Embedded 2Sum with HashSet\r\n", new On2Hashset2SumComplementSolution())
        };
    }
}
