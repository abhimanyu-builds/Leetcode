using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.ContainsDuplicateI;

namespace Leetcode.StrategyRegistry
{
    public static class ContainsDuplicateIStrategies
    {
        public static List<IProblemStrategy<ContainsDuplicateInput, bool>> All => new()
        {
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n) Hashset", new OnHashsetSolution()),
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(nlogn) Sort + Scan", new OnlognSortScanSolution()),
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n²) Brute Force", new On2BruteForceSolution()),
        };
    }
}
