using Leetcode.Interfaces;

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

}