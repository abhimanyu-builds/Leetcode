using Leetcode.Common;
using Leetcode.Models;
using Leetcode.Strategies.SearchInsertPosition;

namespace Leetcode.StrategyRegistry
{
    public static class SearchInsertPositionStrategies
    {
        public static List<IProblemStrategy<SearchInsertPositionInput, int>> All => new()
        {
            new ProblemStrategy<SearchInsertPositionInput, int>("O(logn) Hybrid First Match Or Insert Binary Search", new OlognHybridFirstMatchOrInsertBinarySearchSolution()),
            //new ProblemStrategy<SearchInsertPositionInput, int>("O(logn) Exact Or Insert Binary Search", new OlognExactOrInsertBinarySearchSolution()),
            new ProblemStrategy<SearchInsertPositionInput, int>("O(logn) Lower Bound Binary Search", new OlognLowerBoundBinarySearchSolution()),
            new ProblemStrategy<SearchInsertPositionInput, int>("O(n) Stateful Traversal", new OnStatefulTraversalScanSolution()),
        };
    }
}
