using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.RemoveSequentialAnagrams)]
public class RemoveAnagramsTestCaseProvider : ITestCaseProvider<string[], string[]>
{
    public List<ProblemTest<string[], string[]>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<string[], string[]>.TestCase>()
        {
            // ✅ Static cases
            new(["anagram", "nagaram"], ["anagram"]),
            new(["rat", "car"], ["rat", "car"]),
            new(["a", "a"], ["a"]),
            new(["a", "b"], ["a", "b"]),
            new(["abc", "cba"], ["abc"]),
            new(["abc", "abcc"], ["abc", "abcc"]),
            new(["abcd", "abcc"], ["abcd", "abcc"]),
            new(["aabbcc", "abcabc"], ["aabbcc"]),
            new(["aabbcc", "aabbc"], ["aabbcc", "aabbc"]),
            new(["xxyyzz", "zzyyxx"], ["xxyyzz"]),
            new(["xxyyzz", "zzyyxy"], ["xxyyzz", "zzyyxy"]),
            new(["abc", "cba", "bca", "cab", "bac", "acb"], ["abc"]),
            new(["abc", "def", "fed", "ghi", "ihg", "xyz"], ["abc", "def", "ghi", "xyz"]),
        };

        cases.AddRange(GenerateRandomizedCases());
        cases.AddRange(GenerateAdversarialCases());

        return cases;
    }

    private List<ProblemTest<string[], string[]>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<string[], string[]>.TestCase>();

        for (int i = 0; i < 10; i++)    // Generate 10 random groups per problem constraints
        {
            int count = rand.Next(2, 10);
            var baseWord = new string(Enumerable.Range(0, rand.Next(3, 10))
                .Select(_ => (char)('a' + rand.Next(0, 26))).ToArray());

            var group = new List<string> { baseWord };
            for (int j = 1; j < count; j++)
            {
                var shuffled = baseWord.OrderBy(_ => rand.Next()).ToArray();
                group.Add(new string(shuffled));
            }

            cases.Add(new(group.ToArray(), [group[0]]));

            // Inject mutation for invalid case
            var mutated = baseWord.ToCharArray();
            mutated[rand.Next(mutated.Length)] = (char)('a' + rand.Next(0, 26));
            cases.Add(new([baseWord, new string(mutated)], [baseWord, new string(mutated)]));
        }

        return cases;
    }

    private List<ProblemTest<string[], string[]>.TestCase> GenerateAdversarialCases()
    {
        var cases = new List<ProblemTest<string[], string[]>.TestCase>()
        {
            new(["abcdefghij", "jihgfedcba"], ["abcdefghij"]),
            new(["abcdefghij", "jihgfedcba", "abcdefghij"], ["abcdefghij"]),
            new(["abcde", "edcba", "abcde", "edcba", "abcde"], ["abcde"]),
            //new(["a", "b", "c", "a", "b", "c"], ["a", "b", "c"]),     // Invalid use case per problem description. Only sequential anagrams are to be removed.
            new(["abc", "def", "ghi", "jkl", "mno", "pqr", "stu", "vwx", "yz"], ["abc", "def", "ghi", "jkl", "mno", "pqr", "stu", "vwx", "yz"]),
            //new(["abc", "bca", "cab", "xyz", "zyx", "yxz"], ["abc", "xyz"]),    // Invalid use case per problem description. Only sequential anagrams are to be removed.
            //new(["abc", "def", "fed", "cba", "ghi", "ihg", "xyz", "zyx"], ["abc", "def", "ghi", "xyz"]),    // Invalid use case per problem description. Only sequential anagrams are to be removed.
        };

        return cases;
    }
}