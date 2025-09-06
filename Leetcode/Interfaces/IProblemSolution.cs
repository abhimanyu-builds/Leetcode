namespace Leetcode.Interfaces
{
    public interface IProblemSolution<TInput, TOutput>
    {
        TOutput Solve(TInput input);
    }
}