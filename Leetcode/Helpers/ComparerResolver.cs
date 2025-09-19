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
                    actual != null && actual.Equals(tc.Expected),


                _ => throw new NotSupportedException($"No comparer defined for problem type: {type}")
            };
        }
    }
}