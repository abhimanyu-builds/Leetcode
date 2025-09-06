using Leetcode_test.Interfaces;

namespace Leetcode_test.Common
{
    public interface IProblemStrategy<TInput, TOutput>
    {
        string Name { get; }
        IProblemSolution<TInput, TOutput> Implementation { get; }
    }
}
