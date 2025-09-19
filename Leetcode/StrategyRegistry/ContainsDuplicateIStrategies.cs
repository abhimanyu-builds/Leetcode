using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies;

namespace Leetcode.StrategyRegistry
{
    public static class ContainsDuplicateIStrategies
    {
        public static List<IProblemStrategy<ContainsDuplicateInput, bool>> All => new()
        {
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n) Hashset", new ContainsDuplicateIOnHashsetSolution()),
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(nlogn) Sort + Scan", new ContainsDuplicateIOnlognSortScanSolution()),
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n²) Brute Force", new ContainsDuplicateIOn2BruteForceSolution()),
        };
    }
}
