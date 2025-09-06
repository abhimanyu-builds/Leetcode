using Leetcode.TestHarness;

namespace Leetcode.Interfaces
{
    public interface ITestCaseProvider<TInput, TOutput>
    {
        List<ProblemTest<TInput, TOutput>.TestCase> GetTestCases();
    }
}
