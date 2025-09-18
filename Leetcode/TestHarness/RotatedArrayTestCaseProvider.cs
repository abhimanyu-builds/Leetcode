using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.TestHarness
{
    public class RotatedArrayTestCaseProvider : ITestCaseProvider<RotatedArrayInput, int>
    {
        public List<ProblemTest<RotatedArrayInput, int>.TestCase> GetTestCases()
        {
            var cases = GetStaticTestCases();
            cases.AddRange(GenerateRandomizedCases(100));
            return cases;
        }

        private static List<ProblemTest<RotatedArrayInput, int>.TestCase> GetStaticTestCases()
        {
            var cases = new List<ProblemTest<RotatedArrayInput, int>.TestCase>
            {
                // Fully sorted, no rotation
                new(new RotatedArrayInput([1, 2, 3, 4, 5], 3), 2),
                // Rotated at index 2
                new(new RotatedArrayInput([4, 5, 1, 2, 3], 1), 2),
                // Target at start
                new(new RotatedArrayInput([6, 7, 8, 1, 2, 3, 4, 5], 6), 0),
                // Target at end
                new(new RotatedArrayInput([6, 7, 8, 1, 2, 3, 4, 5], 5), 7),
                // Target not present
                new(new RotatedArrayInput([4, 5, 6, 7, 0, 1, 2], 3), -1),
                // Single element match
                new(new RotatedArrayInput([1], 1), 0),
                // Single element no match
                new(new RotatedArrayInput([1], 2), -1),
                //no duplicates for this problem
            };
            return cases;
        }

        private IEnumerable<ProblemTest<RotatedArrayInput, int>.TestCase> GenerateRandomizedCases(int count)
        {
            List<ProblemTest<RotatedArrayInput, int>.TestCase> testCases = new();
            foreach (PivotDepth pivot in Enum.GetValues(typeof(PivotDepth)))
            {
                foreach (DensityLevel density in Enum.GetValues(typeof(DensityLevel)))
                {
                    testCases.AddRange(GenerateRotatedCases(pivot, density, count / 20));
                }
            }
            return testCases;
        }

        private static List<ProblemTest<RotatedArrayInput, int>.TestCase> GenerateRotatedCases(PivotDepth pivotDepth, DensityLevel duplicateDensity, int count)
        {
            var rand = new Random();
            var cases = new List<ProblemTest<RotatedArrayInput, int>.TestCase>();

            for (int i = 0; i < count; i++)
            {
                int length = rand.Next(10, 101);
                int uniqueCount = duplicateDensity switch
                {
                    DensityLevel.None => length,
                    DensityLevel.Low => rand.Next(length * 9 / 10, length + 1),
                    DensityLevel.Medium => rand.Next(length / 2, length * 3 / 4),
                    DensityLevel.High => rand.Next(length / 10, length / 3),
                    DensityLevel.VeryHigh => rand.Next(1, length / 10 + 1),
                    _ => length
                };

                var uniqueValues = Enumerable.Range(-100, 201).OrderBy(_ => rand.Next()).Take(uniqueCount).ToList();
                var input = uniqueValues.OrderBy(_ => rand.Next()).Take(length).ToArray();                          //uniqueness constraint

                Array.Sort(input);

                int pivotIndex = pivotDepth switch
                {
                    PivotDepth.None => 0,
                    PivotDepth.Shallow => length < 4 ? 1 : rand.Next(1, length / 4),
                    PivotDepth.Medium => rand.Next(length / 4, length * 3 / 4),
                    PivotDepth.Deep => rand.Next(length * 3 / 4, length),
                    _ => 0
                };

                int[] rotated = input.Skip(pivotIndex).Concat(input.Take(pivotIndex)).ToArray();
                int target = rotated[rand.Next(rotated.Length)];

                int expected = Array.IndexOf(rotated, target); // For search problems

                cases.Add(new(new RotatedArrayInput(rotated, target), expected));
            }

            return cases;
        }
    }
}