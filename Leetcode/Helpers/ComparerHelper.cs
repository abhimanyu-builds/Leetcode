using Leetcode.Models;
using Leetcode.TestHarness;

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
}
