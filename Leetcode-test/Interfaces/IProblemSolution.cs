namespace Leetcode_test.Interfaces
{
    public interface IProblemSolution<TInput, TOutput>
    {
        TOutput Solve(TInput input);
    }
}