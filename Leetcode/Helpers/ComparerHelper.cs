using Leetcode.Models;
using Leetcode.TestHarness;
using System;
using System.Reflection;

public static class CompareHelper
{
    public static bool ArraysEqual(int[] actual, int[] expected)
    {
        if (actual == null || expected == null) return false;
        if (actual.Length != expected.Length) return false;
        return actual.SequenceEqual(expected);
    }

    public static bool TripletSetsEqual(List<List<int>> actual, List<List<int>> expected)
    {
        if (actual == null || expected == null) return false;
        if (actual.Count == 0 && actual.Count == expected.Count) return true;
        if (actual.Count != expected.Count) return false;

        var actualSorted = actual.Select(t => t.OrderBy(x => x).ToArray()).ToList();
        var expectedSorted = expected.Select(t => t.OrderBy(x => x).ToArray()).ToList();

        var actualSet = new HashSet<string>(actualSorted.Select(t => string.Join(",", t)));
        var expectedSet = new HashSet<string>(expectedSorted.Select(t => string.Join(",", t)));

        return actualSet.SetEquals(expectedSet);
    }
    public static bool RotatedArrayIndexValid<TInput>(ProblemTest<TInput, int>.TestCase testcase, int actual)
    where TInput : ProblemInput<int[]>
    {
        if (actual < 0) return false;
        return testcase.Input.Numbers[actual] == testcase.Input.Target;
    }
    public static bool PeakIndexValid<TInput>(ProblemTest<TInput, int>.TestCase testcase, int index)
    {
        if (testcase.Input is int[] nums)
        {

            if (nums == null || nums.Length == 0 || index < 0 || index >= nums.Length)
                return false;

            int left = (index == 0) ? int.MinValue : nums[index - 1];
            int right = (index == nums.Length - 1) ? int.MinValue : nums[index + 1];

            return nums[index] > left && nums[index] > right;
        }

        return false;
    }

}
