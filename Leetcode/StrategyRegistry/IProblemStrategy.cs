using Leetcode.Interfaces;

namespace Leetcode.Common
{
    public interface IProblemStrategy<TInput, TOutput>
    {
        string Name { get; }
        IProblemSolution<TInput, TOutput> Implementation { get; }
    }
}
