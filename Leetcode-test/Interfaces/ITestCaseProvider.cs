using Leetcode_test.TestHarness;

namespace Leetcode_test.Interfaces
{
    public interface ITestCaseProvider<TInput, TOutput>
    {
        List<ProblemTest<TInput, TOutput>.TestCase> GetTestCases();
    }
}
