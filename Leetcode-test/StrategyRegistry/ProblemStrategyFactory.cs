using Leetcode_test.Interfaces;
using Leetcode_test.Models;
using Leetcode_test.Strategies;
using Leetcode_test.Two_sum;

namespace Leetcode_test.Common
{
    public enum ProblemType { TwoSum }

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
    }
}