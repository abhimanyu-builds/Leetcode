using Leetcode.Interfaces;
using Leetcode.Models;
using Leetcode.TestHarness;

public class ContainsDuplicateIITestCaseProvider : ITestCaseProvider<ContainsDuplicateInput, bool>
{
    public List<ProblemTest<ContainsDuplicateInput, bool>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<ContainsDuplicateInput, bool>.TestCase>
        {
            // Static edge cases
            new(new ContainsDuplicateInput([1, 2, 3, 1], 3), true),
            new(new ContainsDuplicateInput([1, 0, 1, 1], 1), true),
            new(new ContainsDuplicateInput([1, 2, 3, 1, 2, 3], 2), false),
            new(new ContainsDuplicateInput([1], 0), false),
            new(new ContainsDuplicateInput([1, 1], 0), false),
            new(new ContainsDuplicateInput([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 5), false),
            new(new ContainsDuplicateInput([10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 10], 10), true),
            new(new ContainsDuplicateInput(Enumerable.Repeat(42, 100_000).ToArray(), 1), true),
            new(new ContainsDuplicateInput(Enumerable.Range(1, 100_000).ToArray(), 1), false),
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
            int k = rand.Next(1, size);
            int[] nums = new int[size];

            for (int j = 0; j < size; j++)
                nums[j] = rand.Next(-1_000_000_000, 1_000_000_001);

            bool injectDuplicate = rand.NextDouble() < 0.5;
            if (injectDuplicate)
            {
                int i1 = rand.Next(0, size - k);
                int i2 = i1 + rand.Next(1, k + 1);
                if (i2 < size)
                    nums[i2] = nums[i1];

                cases.Add(new(new ContainsDuplicateInput(nums, k), true));
            }
            else
            {
                nums = Enumerable.Range(rand.Next(-1_000_000_000, 1_000_000_000), size).ToArray();
                cases.Add(new(new ContainsDuplicateInput(nums, k), false));
            }
        }

        return cases;
    }
}