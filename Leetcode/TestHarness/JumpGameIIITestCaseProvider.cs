using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.JumpGameIII)]
public class JumpGameIIITestCaseProvider : ITestCaseProvider<JumpGameIIIInput, bool>
{
    public List<ProblemTest<JumpGameIIIInput, bool>.TestCase> GetTestCases()
    {
        List<ProblemTest<JumpGameIIIInput, bool>.TestCase> cases = GetStaticTestCases();
        cases.AddRange(GenerateAdversarialCases());

        return cases;
    }

    private static List<ProblemTest<JumpGameIIIInput, bool>.TestCase> GetStaticTestCases()
    {
        return new List<ProblemTest<JumpGameIIIInput, bool>.TestCase>
        {
            new(new JumpGameIIIInput([0], 0), true), // trivial success
            new(new JumpGameIIIInput([1, 0], 0), true), // forward jump
            new(new JumpGameIIIInput([1, 1, 0], 0), true), // chained reach
            new(new JumpGameIIIInput([1, 2, 3, 0, 4], 0), true), // unreachable zero
            new(new JumpGameIIIInput([4, 2, 3, 0, 3, 0, 4], 5), true), // multiple zeros
            new(new JumpGameIIIInput([3, 0, 2, 1], 3), false), // backward jump
            new(new JumpGameIIIInput([1, 1, 1, 1, 1, 1], 2), false), // no zero
            new(new JumpGameIIIInput([0, 0, 0, 0], 2), true), // all zeros
            new(new JumpGameIIIInput([1, 2, 3, 4, 0], 0), false), // zero at end
            new(new JumpGameIIIInput([1, 2, 3, 4, 5], 0), false), // no zero
        };
    }

    private List<ProblemTest<JumpGameIIIInput, bool>.TestCase> GenerateAdversarialCases()
    {
        var testCases = new List<ProblemTest<JumpGameIIIInput, bool>.TestCase>();

        // Large plateau with zero at the end
        //int[] plateau = Enumerable.Repeat(1, 49999).Concat([0]).ToArray();
        int[] plateau = Enumerable.Repeat(1, 4999).Concat([0]).ToArray();
        testCases.Add(new(new JumpGameIIIInput(plateau, 0), true));

        // Max size, unreachable zero at end
        //int[] maxSize = Enumerable.Repeat(1, 49999).Concat([2, 0]).ToArray();
        int[] maxSize = Enumerable.Repeat(1, 4999).Concat([2, 0]).ToArray();
        testCases.Add(new(new JumpGameIIIInput(maxSize, 100), false));

        // Cyclic trap
        int[] cyclic = [1, 2, 1, 2, 0];
        testCases.Add(new(new JumpGameIIIInput(cyclic, 0), false));

        // Dense zero cluster, unreachable
        int[] cluster = Enumerable.Repeat(3, 1000).ToArray();
        cluster[999] = 0;
        testCases.Add(new(new JumpGameIIIInput(cluster, 0), true));

        // All zeros
        int[] allZeros = Enumerable.Repeat(0, 1000).ToArray();
        testCases.Add(new(new JumpGameIIIInput(allZeros, 500), true));

        return testCases;
    }
}