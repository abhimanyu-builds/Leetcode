using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

namespace Leetcode.Helpers
{
    public static class ComparerResolver
    {
        public static Func<ProblemTest<TInput, TOutput>.TestCase, TOutput, bool> GetComparer<TInput, TOutput>(ProblemType type)
        {
            return type switch
            {
                ProblemType.TwoSum => (tc, actual) =>
                {
                    var expected = tc.Expected as int[];
                    var result = actual as int[];
                    return expected != null && result != null && CompareHelper.ArraysEqual(result, expected);
                }
                ,

                ProblemType.TwoSumSorted => (tc, actual) =>
                {
                    var expected = tc.Expected as int[];
                    var result = actual as int[];
                    return expected != null && result != null && CompareHelper.ArraysEqual(result, expected);
                }
                ,

                ProblemType.ThreeSum => (tc, actual) =>
                {
                    var expected = tc.Expected as List<List<int>>;
                    var result = actual as List<List<int>>;
                    return expected != null && result != null && CompareHelper.TripletSetsEqual(result, expected);
                }
                ,

                ProblemType.RemoveDuplicatesFromSortedArray => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),

                ProblemType.RemoveElement => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),

                ProblemType.RotatedArray => (tc, actual) =>
                {
                    if (tc.Input is RotatedArrayInput input && actual is int index)
                    {
                        if (index == -1) return tc.Expected != null && tc.Expected.Equals(-1); // target not found
                        return index >= 0 && index < input.Numbers.Length && input.Numbers[index] == input.Target;
                    }
                    return false;
                }
                ,
                ProblemType.ContainsDuplicateI => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected)
                ,
                ProblemType.ContainsDuplicateII => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected)
                ,
                ProblemType.MaxAvgSubArrayI => (tc, actual) =>
                {
                    if (tc.Expected is double expected && actual is double result)
                    {
                        const double epsilon = 1e-5;                        // double.Equals() checks for exact binary equality — not ideal for averages or floating-point math.
                        return Math.Abs(expected - result) < epsilon;       // Using Math.Abs(expected - result) < epsilon ensures comparison within a safe margin of error.
                    }
                    return false;
                }
                ,
                ProblemType.MaxConsecutive1s => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),
                ProblemType.LongestSubarrayAfterOneDeletion => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),
                ProblemType.MaxConsecutive1sIII => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),

                ProblemType.SearchInsertPosition => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),
                ProblemType.LongestHarmoniousSubsequence => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected),

                ProblemType.MergeSortedArrays => (tc, actual) =>
                {
                    if (tc.Input is MergeSortedArraysInput input && tc.Expected is int[] expected && actual is int[] result)
                    {
                        int validLength = input.M + input.N;
                        int[] mutated = result.Take(validLength).ToArray();
                        int[] trimmedExpected = expected.Take(validLength).ToArray();
                        return CompareHelper.ArraysEqual(mutated, trimmedExpected);
                    }
                    return false;
                }
                ,
                ProblemType.ValidMountainArray => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected)
                ,
                ProblemType.FindMountainPeak => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected)
                ,
                ProblemType.FindPeakElement => (tc, actual) =>
                {
                    if (tc is ProblemTest<int[], int>.TestCase typed && actual is int result)
                    {
                        if (typed.Input == null || typed.Input.Length == 0) // Edge case: empty array
                            return typed.Expected.Equals(-1); // Expecting -1 for invalid input
                        return CompareHelper.PeakIndexValid(typed, result);
                    }
                    return false;
                }
                ,
                ProblemType.HillAndValleyCount => (tc, actual) =>
                    actual != null && actual.Equals(tc.Expected)
                ,


                _ => throw new NotSupportedException($"No comparer defined for problem type: {type}")
            };
        }
    }
}