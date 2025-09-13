using Leetcode.Interfaces;
using Leetcode.Models;
using Leetcode.StrategyRegistry;

namespace Leetcode.Common
{
    public enum ProblemType { TwoSum, TwoSumSorted, ThreeSum, RemoveDuplicatesFromSortedArray }

    public class ProblemStrategy<TInput, TOutput> : IProblemStrategy<TInput, TOutput>
    {
        public string Name { get; }
        public IProblemSolution<TInput, TOutput> Implementation { get; }

        public ProblemStrategy(string name, IProblemSolution<TInput, TOutput> implementation)
        {
            Name = name;
            Implementation = implementation;
        }
    }

    public static class ProblemStrategyFactory
    {
        public static IEnumerable<IProblemStrategy<TwoSumInput, int[]>> GetTwoSumStrategies() => TwoSumStrategies.All;
        public static IEnumerable<IProblemStrategy<TwoSumSortedInput, int[]>> GetTwoSumSortedStrategies() => TwoSumSortedStrategies.All;
        public static IEnumerable<IProblemStrategy<ThreeSumInput, List<List<int>>>> GetThreeSumStrategies() => ThreeSumStrategies.All;
        public static IEnumerable<IProblemStrategy<int[], int>> GetRemoveDuplicatesStrategies() => RemoveDuplicatesStrategies.All;
    }
}