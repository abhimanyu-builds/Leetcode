using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.ContainsDuplicateII;

namespace Leetcode.StrategyRegistry
{
    public static class ContainsDuplicateIIStrategies
    {
        public static List<IProblemStrategy<ContainsDuplicateInput, bool>> All => new()
        {
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n²) Brute Force", new On2BruteForceSolution()),
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n) Hashset", new OnHashsetSolution()),
            new ProblemStrategy<ContainsDuplicateInput, bool>("O(n) Dictionary", new OnDictionarySolution()),
        };
    }
}
