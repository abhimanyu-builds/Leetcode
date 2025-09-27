using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;
[TestCaseProviderExport(ProblemType.ContainsDuplicateI)]
public class ContainsDuplicateITestCaseProvider : ITestCaseProvider<ContainsDuplicateInput, bool>
{
    public List<ProblemTest<ContainsDuplicateInput, bool>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<ContainsDuplicateInput, bool>.TestCase>
        {
            // Static edge cases
            new(new ContainsDuplicateInput([1, 2, 3, 1]), true),
            new(new ContainsDuplicateInput([1, 2, 3, 4]), false),
            new(new ContainsDuplicateInput([1]), false),
            new(new ContainsDuplicateInput([1, 1]), true),
            new(new ContainsDuplicateInput([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]), false),
            new(new ContainsDuplicateInput([10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 10]), true),
            new(new ContainsDuplicateInput(Enumerable.Repeat(42, 100_000).ToArray()), true),
            new(new ContainsDuplicateInput(Enumerable.Range(1, 100_000).ToArray()), false),
        };

        cases.AddRange(GenerateRandomizedCases());
        return cases;
    }

    private List<ProblemTest<ContainsDuplicateInput, bool>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<ContainsDuplicateInput, bool>.TestCase>();

        for (int i = 0; i < 20; i++)
        {
            int size = rand.Next(10, 1000);
            int[] nums = new int[size];

            for (int j = 0; j < size; j++)
                nums[j] = rand.Next(-1_000_000_000, 1_000_000_001);

            // 50% chance to inject a duplicate
            bool injectDuplicate = rand.NextDouble() < 0.5;
            if (injectDuplicate)
            {
                int dupIndex = rand.Next(1, size);
                nums[dupIndex] = nums[0];
                cases.Add(new(new ContainsDuplicateInput(nums), true));
            }
            else
            {
                // Ensure uniqueness
                nums = Enumerable.Range(rand.Next(-1_000_000_000, 1_000_000_000), size).ToArray();
                cases.Add(new(new ContainsDuplicateInput(nums), false));
            }
        }

        return cases;
    }
}