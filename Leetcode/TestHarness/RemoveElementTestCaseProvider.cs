using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.TestHarness
{
    public class RemoveElementTestCaseProvider : ITestCaseProvider<RemoveElementInput, int>
    {
        public List<ProblemTest<RemoveElementInput, int>.TestCase> GetTestCases()
        {
            var cases = GetStaticTestCases();
            cases.AddRange(GenerateRandomizedCases(200));
            return cases;
        }

        private static List<ProblemTest<RemoveElementInput, int>.TestCase> GetStaticTestCases()
        {
            var cases = new List<ProblemTest<RemoveElementInput, int>.TestCase>
            {
                new(new RemoveElementInput([3, 2, 2, 3], 3), 2),                  // basic removal
                new(new RemoveElementInput([0,1,2,2,3,0,4,2], 2), 5),             // multiple occurrences
                new(new RemoveElementInput([1, 1, 1, 1], 1), 0),                  // all elements removed
                new(new RemoveElementInput([1, 2, 3, 4], 5), 4),                  // no match
                new(new RemoveElementInput([], 0), 0),                            // empty array
                new(new RemoveElementInput([2], 2), 0),                           // single element match
                new(new RemoveElementInput([2], 3), 1),                           // single element no match
                new(new RemoveElementInput([4, 5, 6, 4, 4, 7], 4), 3),            // scattered duplicates
                new(new RemoveElementInput([0, 0, 0, 0, 0], 0), 0),               // all zeroes
                new(new RemoveElementInput([-1, -2, -3, -1], -1), 2),             // negative values
                new(new RemoveElementInput([1, 2, 3, 4, 5], 3), 4),               // middle match
                new(new RemoveElementInput([1, 2, 3, 4, 5], 1), 4),               // match at start
                new(new RemoveElementInput([1, 2, 3, 4, 5], 5), 4),               // match at end
                new(new RemoveElementInput([2,2,3], 2), 1),                       // single element non-match at end
                new(new RemoveElementInput(Enumerable.Range(1, 100000).ToArray(), 50000), 99999), // large input
            };
            return cases;
        }
        private static List<ProblemTest<RemoveElementInput, int>.TestCase> GenerateRandomizedCases(int count = 5)
        {
            var rand = new Random();
            var cases = new List<ProblemTest<RemoveElementInput, int>.TestCase>();

            for (int i = 0; i < count; i++)
            {
                int length = rand.Next(0, 101); // nums.length between 0 and 100
                int[] input = new int[length];

                for (int j = 0; j < length; j++)
                    input[j] = rand.Next(0, 51); // nums[i] between 0 and 50

                int valToRemove = rand.Next(0, 101); // val between 0 and 100

                int expected = input.Count(x => x != valToRemove);

                // Clone input to avoid mutation during test execution
                int[] inputCopy = input.ToArray();

                cases.Add(new(new RemoveElementInput(inputCopy, valToRemove), expected));
            }

            return cases;
        }
    }
}