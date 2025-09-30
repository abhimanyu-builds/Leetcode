namespace Leetcode.Interfaces
{
    public interface IProblemStrategy<TInput, TOutput>
    {
        string Name { get; }
        bool IsInPlace { get; }
        IProblemSolution<TInput, TOutput> Implementation { get; }
    }
}
