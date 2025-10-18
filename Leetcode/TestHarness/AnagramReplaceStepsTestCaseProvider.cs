using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.AnagramReplaceSteps)]
public class AnagramReplaceStepsTestCaseProvider : ITestCaseProvider<string[], int>
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
            int len = rand.Next(1, 5001);
            var s = new string(Enumerable.Range(0, len).Select(_ => (char)('a' + rand.Next(0, 26))).ToArray());
            var t = new string(Enumerable.Range(0, len).Select(_ => (char)('a' + rand.Next(0, 26))).ToArray());

            cases.Add(new([s, t], ComputeSteps(s, t)));
        }

        return cases;
    }

    private List<ProblemTest<string[], int>.TestCase> GenerateAdversarialCases()
    {
        var cases = new List<ProblemTest<string[], int>.TestCase>();

        // Max length, full mismatch
        var s1 = new string('a', 50_000);
        var t1 = new string('b', 50_000);
        cases.Add(new([s1, t1], 50_000));

        // Max length, perfect match
        var s2 = new string('z', 50_000);
        var t2 = new string('z', 50_000);
        cases.Add(new([s2, t2], 0));

        // Half-half swap
        var s3 = new string('a', 25_000) + new string('b', 25_000);
        var t3 = new string('b', 25_000) + new string('a', 25_000);
        cases.Add(new([s3, t3], 0));

        // Skewed distribution
        var s4 = new string('a', 49_999) + "z";
        var t4 = new string('a', 49_998) + "zz";
        cases.Add(new([s4, t4], 1));

        return cases;
    }

    private int ComputeSteps(string s, string t)
    {
        var freq = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i] - 'a']++;
            freq[t[i] - 'a']--;
        }

        return freq.Where(x => x < 0).Sum(x => -x);
    }
}