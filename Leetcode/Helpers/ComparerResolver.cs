using Leetcode.TestHarness;
using Leetcode.Metadata;
using Leetcode.Models;

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
                    if (tc.Input is RotatedArrayInput rai && actual is int index && index >= 0)
                        return rai.Numbers[index] == rai.Target;
                    return false;
                }
                ,

                _ => throw new NotSupportedException($"No comparer defined for problem type: {type}")
            };
        }
    }
}