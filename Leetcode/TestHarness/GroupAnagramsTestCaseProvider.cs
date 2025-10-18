using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.GroupAnagrams)]
public class GroupAnagramsTestCaseProvider : ITestCaseProvider<string[], string[][]>
{
    public List<ProblemTest<string[], string[][]>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<string[], string[][]>.TestCase>
        {
            // ✅ Static cases
            new(["eat", "tea", "tan", "ate", "nat", "bat"], [["eat", "tea", "ate"], ["tan", "nat"], ["bat"]]),
            new([""], [[""]]),
            new(["a"], [["a"]]),
            new(["abc", "bca", "cab", "xyz", "zyx"], [["abc", "bca", "cab"], ["xyz", "zyx"]]),
            new(["bdddddddddd", "bbbbbbbbbbc"], [["bdddddddddd"], ["bbbbbbbbbbc"]]), // signature collision check
            new(["abc", "def", "ghi"], [["abc"], ["def"], ["ghi"]]), // no anagrams
            new(["a", "b", "c", "a"], [["a", "a"], ["b"], ["c"]]),
        };

        cases.AddRange(GenerateRandomizedCases());
        cases.AddRange(GenerateAdversarialCases());

        return cases;
    }

    private List<ProblemTest<string[], string[][]>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<string[], string[][]>.TestCase>();

        for (int i = 0; i < 5; i++)
        {
            int groupCount = rand.Next(2, 5);
            var allWords = new List<string>();
            var expectedGroups = new List<string[]>();

            for (int g = 0; g < groupCount; g++)
            {
                int wordLength = rand.Next(1, 10);
                var baseChars = Enumerable.Range(0, wordLength)
                    .Select(_ => (char)('a' + rand.Next(0, 26)))
                    .ToArray();

                int anagramCount = rand.Next(2, 5);
                var group = new List<string>();

                for (int j = 0; j < anagramCount; j++)
                {
                    var shuffled = baseChars.OrderBy(_ => rand.Next()).ToArray();
                    group.Add(new string(shuffled));
                }

                allWords.AddRange(group);
                expectedGroups.Add([.. group]);
            }

            cases.Add(new([.. allWords], [.. expectedGroups]));
        }

        return cases;
    }

    private List<ProblemTest<string[], string[][]>.TestCase> GenerateAdversarialCases()
    {
        var cases = new List<ProblemTest<string[], string[][]>.TestCase>
        {
            // 🔥 Max group size with repeated characters
            new(Enumerable.Repeat(new string('a', 100), 100).ToArray(), [Enumerable.Repeat(new string('a', 100), 100).ToArray()]),

            // 🔥 Many small unique groups
            new(Enumerable.Range(0, 100).Select(i => new string(Enumerable.Range(0, 5).Select(j => (char)('a' + (i + j) % 26)).ToArray())).Concat(Enumerable.Range(0, 100)
                                        .Select(i => new string(Enumerable.Range(0, 5).Select(j => (char)('a' + (i + j) % 26)).ToArray()))).ToArray(),
                Enumerable.Range(0, 100).Select(i => new string(Enumerable.Range(0, 5).Select(j => (char)('a' + (i + j) % 26)).ToArray())).Concat(Enumerable.Range(0, 100)
                                        .Select(i => new string(Enumerable.Range(0, 5).Select(j => (char)('a' + (i + j) % 26)).ToArray()))).GroupBy(s => new string(s.OrderBy(c => c).ToArray())).Select(g => g.ToArray()).ToArray()),

            // 🔥 Signature collision stress test
            new(["bdddddddddd", "bbbbbbbbbbc"], [["bdddddddddd"], ["bbbbbbbbbbc"]]),

            // 🔥 Empty strings
            new(["", "", ""], [["", "", ""]]),

            // 🔥 Mixed length anagrams
            new(["a", "ab", "ba", "abc", "cab", "bca", "abcd", "bcda", "dabc"],
                [["a"], ["ab", "ba"], ["abc", "cab", "bca"], ["abcd", "bcda", "dabc"]]),
        };

        return cases;
    }
}