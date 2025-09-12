namespace Leetcode.Interfaces
{
    public interface IProblemSolution<TInput, TOutput>
    {
        Task<TOutput> SolveAsync(TInput input);
    }
}