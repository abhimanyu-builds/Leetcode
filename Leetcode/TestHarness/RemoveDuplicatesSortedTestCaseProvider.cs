using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.TestHarness
{
    [TestCaseProviderExport(ProblemType.RemoveDuplicatesFromSortedArray)]
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

        private IEnumerable<ProblemTest<int[], int>.TestCase> GenerateRandomizedCases(int count = 5)
        {
            List<ProblemTest<int[], int>.TestCase> testCases = new();
            foreach (DensityLevel DensityLevel in Enum.GetValues(typeof(DensityLevel)))
            {
                testCases.AddRange(GenerateRemoveDuplicatesCases(DensityLevel, count / 5));
            }
            return testCases;
        }
        private static List<ProblemTest<int[], int>.TestCase> GenerateRemoveDuplicatesCases(DensityLevel density, int count = 5)
        {
            var rand = new Random();
            var cases = new List<ProblemTest<int[], int>.TestCase>();

            for (int i = 0; i < count; i++)
            {
                int length = rand.Next(10, 30_001);
                int uniqueCount = density switch
                {
                    DensityLevel.None => length,
                    DensityLevel.Low => rand.Next(length * 9 / 10, length + 1),
                    DensityLevel.Medium => rand.Next(length / 2, length * 3 / 4),
                    DensityLevel.High => rand.Next(length / 10, length / 3),
                    DensityLevel.VeryHigh => rand.Next(1, length / 10 + 1),
                    _ => length
                };

                var uniqueValues = Enumerable.Range(-100, 201).OrderBy(_ => rand.Next()).Take(uniqueCount).ToList();
                int[] input = new int[length];
                for (int j = 0; j < length; j++)
                    input[j] = uniqueValues[rand.Next(uniqueValues.Count)];

                Array.Sort(input);
                int expected = input.Distinct().Count();
                cases.Add(new(input, expected));
            }

            return cases;
        }
    }
}