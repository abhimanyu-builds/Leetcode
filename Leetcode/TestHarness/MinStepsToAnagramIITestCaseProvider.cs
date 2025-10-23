using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.MinStepsToAnagramII)]
public class MinStepsToAnagramIITestCaseProvider : ITestCaseProvider<string[], int>
{
    public List<ProblemTest<string[], int>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<string[], int>.TestCase>()
        {
            // Static cases
            new(["bab", "aba"], 1),
            new(["leetcode", "practice"], 5),
            new(["anagram", "mangaar"], 0),
            new(["a", "b"], 1),
            new(["abc", "cba"], 0),
            new(["aaa", "bbb"], 3),
            new(["aabbcc", "abcabc"], 0),
            new(["abcd", "abcf"], 1),
            new(["zzzz", "zzzz"], 0),
            new(["abcde", "edcba"], 0),
            new(["abcde", "aaaaa"], 4),
            new(["abc", "ab"], 1),
            new(["a", "abc"], 2),
            new(["abc", "defgh"], 5),
            new(["xxyyzz", "xyz"], 3),
            new(["", "abc"], 3),
            new(["abc", ""], 3),
        };

        cases.AddRange(GenerateRandomizedCases());
        cases.AddRange(GenerateAdversarialCases());

        return cases;
    }

    private List<ProblemTest<string[], int>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<string[], int>.TestCase>();

        for (int i = 0; i < 10; i++)
        {
            int lenS = rand.Next(1, 200_001);
            int lenT = rand.Next(1, 200_001);

            var s = new string(Enumerable.Range(0, lenS).Select(_ => (char)('a' + rand.Next(0, 26))).ToArray());
            var t = new string(Enumerable.Range(0, lenT).Select(_ => (char)('a' + rand.Next(0, 26))).ToArray());

            cases.Add(new([s, t], ComputeSteps(s, t)));
        }

        return cases;
    }

    private List<ProblemTest<string[], int>.TestCase> GenerateAdversarialCases()
    {
        var cases = new List<ProblemTest<string[], int>.TestCase>();

        // Max length, full mismatch
        var s1 = new string('a', 200_000);
        var t1 = new string('b', 200_000);
        cases.Add(new([s1, t1], 400_000));

        // Max length, perfect match
        var s2 = new string('z', 200_000);
        var t2 = new string('z', 200_000);
        cases.Add(new([s2, t2], 0));

        // Half-half swap
        var s3 = new string('a', 100_000) + new string('b', 100_000);
        var t3 = new string('b', 100_000) + new string('a', 100_000);
        cases.Add(new([s3, t3], 0));

        // Skewed distribution
        var s4 = new string('a', 199_999) + "z";
        var t4 = new string('a', 199_998) + "zz";
        cases.Add(new([s4, t4], 1));

        // Unequal length, full mismatch
        var s5 = new string('a', 200_000);
        var t5 = new string('b', 1);
        cases.Add(new([s5, t5], 200_001));

        var s6 = new string('c', 1);
        var t6 = new string('d', 200_000);
        cases.Add(new([s6, t6], 200_001));

        // Unequal length, partial overlap
        var s7 = new string('x', 150_000) + new string('y', 50_000);
        var t7 = new string('x', 100_000) + new string('z', 100_000);
        cases.Add(new([s7, t7], 100_000));

        return cases;
    }

    private int ComputeSteps(string s, string t)
    {
        var freq = new int[26];
        foreach (var ch in s) freq[ch - 'a']++;
        foreach (var ch in t) freq[ch - 'a']--;

        return freq.Sum(x => Math.Abs(x));
    }
}