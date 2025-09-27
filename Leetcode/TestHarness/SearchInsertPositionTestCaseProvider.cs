using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.SearchInsertPosition)]

public class SearchInsertPositionTestCaseProvider : ITestCaseProvider<SearchInsertPositionInput, int>
{
    public List<ProblemTest<SearchInsertPositionInput, int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<SearchInsertPositionInput, int>.TestCase>();
        cases.AddRange(GetStaticTestCases());
        cases.AddRange(GetEdgeCases());
        cases.AddRange(GetContrastCases());
        cases.AddRange(GenerateRandomizedCases());
        return cases;
    }

    private static List<ProblemTest<SearchInsertPositionInput, int>.TestCase> GetStaticTestCases()
    {
        return new List<ProblemTest<SearchInsertPositionInput, int>.TestCase>
        {
            new(new SearchInsertPositionInput([1, 3, 5, 6], 5), 2),
            new(new SearchInsertPositionInput([1, 3, 5, 6], 2), 1),
            new(new SearchInsertPositionInput([1, 3, 5, 6], 7), 4),
            new(new SearchInsertPositionInput([1, 3, 5, 6], 0), 0),
            new(new SearchInsertPositionInput([1], 0), 0),
            new(new SearchInsertPositionInput([1], 1), 0),
            new(new SearchInsertPositionInput([1], 2), 1),
        };
    }

    private static List<ProblemTest<SearchInsertPositionInput, int>.TestCase> GetEdgeCases()
    {
        return new List<ProblemTest<SearchInsertPositionInput, int>.TestCase>
        {
            new(new SearchInsertPositionInput([], 5), 0),
            new(new SearchInsertPositionInput([10], 10), 0),
            new(new SearchInsertPositionInput([10], 5), 0),
            new(new SearchInsertPositionInput([10], 15), 1),
            new(new SearchInsertPositionInput([1, 3, 5, 7, 9], 8), 4),
        };
    }
    private static List<ProblemTest<SearchInsertPositionInput, int>.TestCase> GetContrastCases()
    {
        return new List<ProblemTest<SearchInsertPositionInput, int>.TestCase>
    {
        // Exact match in middle
        new(new SearchInsertPositionInput([10, 20, 30, 40, 50], 30), 2),

        // Insert at beginning
        new(new SearchInsertPositionInput([10, 20, 30, 40, 50], 5), 0),

        // Insert at end
        new(new SearchInsertPositionInput([10, 20, 30, 40, 50], 55), 5),

        // Insert between duplicates (lower bound vs traversal)
        new(new SearchInsertPositionInput([10, 20, 20, 20, 30], 20), 1),

        // Insert before first duplicate
        new(new SearchInsertPositionInput([10, 20, 20, 20, 30], 19), 1),

        // Insert after last duplicate
        new(new SearchInsertPositionInput([10, 20, 20, 20, 30], 21), 4),

        // Insert between tight values
        new(new SearchInsertPositionInput([1, 2, 3, 4, 5], 3), 2),

        // Insert between sparse values
        new(new SearchInsertPositionInput([10, 100, 1000], 500), 2),

        // Insert into large uniform array
        new(new SearchInsertPositionInput(Enumerable.Repeat(42, 1000).ToArray(), 42), 0),

        // Insert into large ascending array
        new(new SearchInsertPositionInput(Enumerable.Range(0, 1000).ToArray(), 999), 999),

        // Insert just beyond last element
        new(new SearchInsertPositionInput(Enumerable.Range(0, 1000).ToArray(), 1000), 1000),

        // Insert just before first element
        new(new SearchInsertPositionInput(Enumerable.Range(1, 1000).ToArray(), 0), 0),

        // Insert into empty array
        new(new SearchInsertPositionInput([], 42), 0),

        // Insert into single-element array (match)
        new(new SearchInsertPositionInput([42], 42), 0),

        // Insert into single-element array (before)
        new(new SearchInsertPositionInput([42], 10), 0),

        // Insert into single-element array (after)
        new(new SearchInsertPositionInput([42], 100), 1),
    };
    }

    private List<ProblemTest<SearchInsertPositionInput, int>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<SearchInsertPositionInput, int>.TestCase>();
        Random rand = new();

        for (int t = 0; t < 10; t++)
        {
            int size = rand.Next(1, 1000);
            int[] nums = Enumerable.Range(0, size).Select(_ => rand.Next(0, 10_000)).Distinct().OrderBy(x => x).ToArray();
            int target = rand.Next(0, 10_000);

            int expected = Array.BinarySearch(nums, target);
            if (expected < 0) expected = ~expected;

            testCases.Add(new(new SearchInsertPositionInput(nums, target), expected));
        }

        return testCases;
    }
}