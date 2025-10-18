using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.TestHarness;

[TestCaseProviderExport(ProblemType.ValidAnagram)]
public class ValidAnagramTestCaseProvider : ITestCaseProvider<string[], bool>
{
    public List<ProblemTest<string[], bool>.TestCase> GetTestCases()
    {
        var cases = new List<ProblemTest<string[], bool>.TestCase>()
        {
            // ✅ Static cases
            new(["anagram", "nagaram"], true),
            new(["rat", "car"], false),
            new(["a", "a"], true),
            new(["a", "b"], false),
            new(["abc", "cba"], true),
            new(["abc", "abcc"], false),
            new(["abcd", "abcc"], false),
            new(["aabbcc", "abcabc"], true),
            new(["aabbcc", "aabbc"], false),
            new(["xxyyzz", "zzyyxx"], true),
            new(["xxyyzz", "zzyyxy"], false),
        };

        cases.AddRange(GenerateRandomizedCases());
        cases.AddRange(GenerateAdversarialCases());

        return cases;
    }

    private List<ProblemTest<string[], bool>.TestCase> GenerateRandomizedCases()
    {
        var rand = new Random();
        var cases = new List<ProblemTest<string[], bool>.TestCase>();

        for (int i = 0; i < 10; i++)
        {
            int size = rand.Next(1, 5000);
            var chars = Enumerable.Range(0, size)
                .Select(_ => (char)('a' + rand.Next(0, 26)))
                .ToArray();

            var s = new string(chars);
            var t = new string(chars.OrderBy(_ => rand.Next()).ToArray());

            cases.Add(new([s, t], true));

            // Inject mutation for invalid case
            var mutated = t.ToCharArray();
            mutated[rand.Next(size)] = (char)('a' + rand.Next(0, 26));
            cases.Add(new([s, new string(mutated)], false));
        }

        return cases;
    }

    private List<ProblemTest<string[], bool>.TestCase> GenerateAdversarialCases()
    {
        var cases = new List<ProblemTest<string[], bool>.TestCase>()
        {
            new([new string('a', 50000), new string('a', 49999) + "b"], false), // max length mismatch
            new([new string('a', 25000) + new string('b', 25000), new string('b', 25000) + new string('a', 25000)], true), // max valid
            new([new string('a', 25000) + new string('b', 25000), new string('b', 25000) + new string('a', 24999) + "c"], false), // near-max invalid
            new(["abcdefghijklmnopqrstuvwxyz", "zyxwvutsrqponmlkjihgfedcba"], true), // full alphabet
            new(["abcabcabcabcabc", "cbacbacbacbacba"], true), // repeated pattern
            new(["abcabcabcabcabc", "cbacbacbacbacbb"], false), // off-by-one
        };

        return cases;
    }
}