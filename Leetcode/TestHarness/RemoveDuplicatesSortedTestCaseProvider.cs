using Leetcode.Interfaces;

namespace Leetcode.TestHarness
{
    public class RemoveDuplicatesSortedTestCaseProvider : ITestCaseProvider<int[], int>
    {
        public List<ProblemTest<int[], int>.TestCase> GetTestCases()
        {
            var cases = GetStaticTestCases();
            cases.AddRange(GenerateRandomizedCases(200));
            return cases;
        }

        private static List<ProblemTest<int[], int>.TestCase> GetStaticTestCases() => [
            new([], 0), // No elements
            new([1], 1), // Single element
            new([2, 2, 2, 2], 1), // All duplicates
            new([1, 2, 3, 4], 4), // No duplicates
            new([1, 1, 2, 2, 3, 3], 3), // Alternating duplicates
            new([0, 0, 1, 2, 3], 4), // Duplicates only at start
            new([1, 2, 3, 4, 4, 4], 4), // Duplicates only at end
            new([-3, -3, -2, -1, -1, 0], 4), // Negative numbers
            new([-1, -1, 0, 1, 1, 2, 3, 3], 5), // Mixed range
            new([5, 5, 5, 5, 5, 6], 2) // Large duplicates block
        ];

        private static List<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases(int count = 5)
        {
            var rand = new Random();
            var cases = new List<ProblemTest<int[], int>.TestCase>();

            for (int i = 0; i < count; i++)
            {
                int length = rand.Next(1, 30_001); // Length between 1 and 30,000
                int[] input = new int[length];

                for (int j = 0; j < length; j++)
                    input[j] = rand.Next(-100, 101); // Values between -100 and 100

                Array.Sort(input);

                int expected = input.Distinct().Count();

                cases.Add(new(input, expected));
            }

            return cases;
        }
    }
}