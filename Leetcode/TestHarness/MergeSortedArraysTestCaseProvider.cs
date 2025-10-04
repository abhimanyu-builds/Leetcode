using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.MergeSortedArrays)]
public class MergeSortedArraysTestCaseProvider : ITestCaseProvider<MergeSortedArraysInput, int[]>
{
    public List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>
        {
            // Static edge cases
            new(new MergeSortedArraysInput([0], 0, [1], 1), [1]),
            new(new MergeSortedArraysInput([1], 1, [], 0), [1]),
            new(new MergeSortedArraysInput([1,2,3,0,0,0], 3, [2,5,6], 3), [1,2,2,3,5,6]),
            new(new MergeSortedArraysInput([2,0], 1, [1], 1), [1,2]),
            new(new MergeSortedArraysInput([4,5,6,0,0,0], 3, [1,2,3], 3), [1,2,3,4,5,6]),
            new(new MergeSortedArraysInput([-5,-3,-1,0,0,0], 3, [-4,-2,0], 3), [-5,-4,-3,-2,-1,0]),
            new(new MergeSortedArraysInput([1,2,2,0,0,0], 3, [2,2,3], 3), [1,2,2,2,2,3]),
        };

        cases.AddRange(GenerateRandomizedCases(10));
        cases.AddRange(GenerateFrontLoadedCases(5));
        cases.AddRange(GenerateBackLoadedCases(5));
        cases.AddRange(GenerateEvenlyDistributedCases(5));
        cases.AddRange(GenerateOverlappingCases(5));
        cases.AddRange(GenerateStressCases());
        cases.AddRange(GenerateDefensiveCases());

        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateRandomizedCases(int count)
    {
        var rand = new Random();
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>();

        for (int i = 0; i < count; i++)
        {
            int m = rand.Next(5, 100);
            int n = rand.Next(5, 100);

            var arr1 = Enumerable.Range(0, m).Select(_ => rand.Next(-1000, 1000)).OrderBy(x => x).ToArray();
            var arr2 = Enumerable.Range(0, n).Select(_ => rand.Next(-1000, 1000)).OrderBy(x => x).ToArray();

            var padded = arr1.Concat(new int[n]).ToArray();
            var expected = arr1.Concat(arr2).OrderBy(x => x).ToArray();

            cases.Add(new(new MergeSortedArraysInput(padded, m, arr2, n), expected));
        }

        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateFrontLoadedCases(int count)
    {
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>();
        for (int i = 0; i < count; i++)
        {
            var arr1 = Enumerable.Range(1, 50).ToArray();
            var arr2 = Enumerable.Range(1000, 5).ToArray();
            var padded = arr1.Concat(new int[arr2.Length]).ToArray();
            var expected = arr1.Concat(arr2).OrderBy(x => x).ToArray();
            cases.Add(new(new MergeSortedArraysInput(padded, arr1.Length, arr2, arr2.Length), expected));
        }
        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateBackLoadedCases(int count)
    {
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>();
        for (int i = 0; i < count; i++)
        {
            var arr1 = Enumerable.Range(-1000, 5).ToArray();
            var arr2 = Enumerable.Range(10, 50).ToArray();
            var padded = arr1.Concat(new int[arr2.Length]).ToArray();
            var expected = arr1.Concat(arr2).OrderBy(x => x).ToArray();
            cases.Add(new(new MergeSortedArraysInput(padded, arr1.Length, arr2, arr2.Length), expected));
        }
        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateEvenlyDistributedCases(int count)
    {
        var rand = new Random();
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>();
        for (int i = 0; i < count; i++)
        {
            var baseSet = Enumerable.Range(0, 100).Select(_ => rand.Next(-500, 500)).OrderBy(x => x).ToArray();
            var arr1 = baseSet.Where((_, idx) => idx % 2 == 0).ToArray();
            var arr2 = baseSet.Where((_, idx) => idx % 2 != 0).ToArray();
            var padded = arr1.Concat(new int[arr2.Length]).ToArray();
            var expected = arr1.Concat(arr2).OrderBy(x => x).ToArray();
            cases.Add(new(new MergeSortedArraysInput(padded, arr1.Length, arr2, arr2.Length), expected));
        }
        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateOverlappingCases(int count)
    {
        var rand = new Random();
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>();

        for (int i = 0; i < count; i++)
        {
            int baseStart = rand.Next(-1000, 1000);
            int overlap = rand.Next(10, 100);
            int[] arr1 = Enumerable.Range(baseStart, overlap).ToArray();
            int[] arr2 = Enumerable.Range(baseStart + rand.Next(-5, 5), overlap).ToArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            var padded = arr1.Concat(new int[arr2.Length]).ToArray();
            var expected = arr1.Concat(arr2).OrderBy(x => x).ToArray();
            cases.Add(new(new MergeSortedArraysInput(padded, arr1.Length, arr2, arr2.Length), expected));
        }

        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateStressCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>();

        for (int i = 0; i < 3; i++)
        {
            int m = 100_000;
            int n = 100_000;

            int[] arr1 = Enumerable.Range(0, m).Select(_ => rand.Next(-1_000_000, 1_000_000)).OrderBy(x => x).ToArray();
            int[] arr2 = Enumerable.Range(0, n).Select(_ => rand.Next(-1_000_000, 1_000_000)).OrderBy(x => x).ToArray();

            var padded = arr1.Concat(new int[n]).ToArray();
            var expected = arr1.Concat(arr2).OrderBy(x => x).ToArray();
            cases.Add(new(new MergeSortedArraysInput(padded, m, arr2, n), expected));
        }

        return cases;
    }

    private IEnumerable<ProblemTest<MergeSortedArraysInput, int[]>.TestCase> GenerateDefensiveCases()
    {
        var cases = new List<ProblemTest<MergeSortedArraysInput, int[]>.TestCase>
        {
            new(new MergeSortedArraysInput([0], 0, [1], 1), [1]),
            new(new MergeSortedArraysInput([1], 1, [], 0), [1]),
            new(new MergeSortedArraysInput([0], 0, [], 0), []),
            new(new MergeSortedArraysInput([1,0], 1, [2], 1), [1,2]),
            new(new MergeSortedArraysInput([0,0], 0, [1,2], 2), [1,2]),
        };

        return cases;
    }
}