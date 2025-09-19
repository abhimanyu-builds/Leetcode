using Leetcode.Interfaces;
using Leetcode.Models;
using Leetcode.StrategyRegistry;

namespace Leetcode.Common
{
    public class ProblemStrategy<TInput, TOutput> : IProblemStrategy<TInput, TOutput>
    {
        public string Name { get; }
        public bool IsInPlace { get; }
        public bool HasDuplicates { get; }
        public IProblemSolution<TInput, TOutput> Implementation { get; }

        public ProblemStrategy(string name, IProblemSolution<TInput, TOutput> implementation, bool isInPlace = false, bool hasDuplicates = false)
        {
            Name = name;
            IsInPlace = isInPlace;
            HasDuplicates = hasDuplicates;
            Implementation = implementation;
        }
    }

    public static class ProblemStrategyFactory
    {
        public static IEnumerable<IProblemStrategy<TwoSumInput, int[]>> GetTwoSumStrategies() => TwoSumStrategies.All;
        public static IEnumerable<IProblemStrategy<TwoSumSortedInput, int[]>> GetTwoSumSortedStrategies() => TwoSumSortedStrategies.All;
        public static IEnumerable<IProblemStrategy<ThreeSumInput, List<List<int>>>> GetThreeSumStrategies() => ThreeSumStrategies.All;
        public static IEnumerable<IProblemStrategy<int[], int>> GetRemoveDuplicatesStrategies() => RemoveDuplicatesStrategies.All;
        public static IEnumerable<IProblemStrategy<RemoveElementInput, int>> GetRemoveElementStrategies() => RemoveElementStrategies.All;
        public static IEnumerable<IProblemStrategy<RotatedArrayInput, int>> GetRotatedArrayStrategies() => RotatedArrayStrategies.All;
        public static IEnumerable<IProblemStrategy<ContainsDuplicateInput, bool>> GetContainsDuplicateIStrategies() => ContainsDuplicateIStrategies.All;
    }
}