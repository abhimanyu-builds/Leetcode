using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.ValidAnagram
{
    [StrategyExport(
        ProblemType.ValidAnagram,
        name: "O(n) Single Pass Lookup Dictionary",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnSingleDictionarySolution : IProblemSolution<string[], bool>
    {
        public bool Solve(string[] strings)
        {

            // Submission: https://leetcode.com/problems/valid-anagram/submissions/1804671765/

            // Analysis:
            // If s or t is null or empty, return false — though this can't happen under the given constraints.
            // If lengths differ, they can't be anagrams — early exit.
            // Use one dictionary to track character counts:
            //   - Add 1 for each char in s
            //   - Subtract 1 for each char in t
            // After the loop, if all values in the dictionary are zero, it's a valid anagram.
            // If any value isn't zero, there's a mismatch — return false.
            // Time: O(n), Space: O(1) since only lowercase letters (max 26 keys)
            // Relies on problem constraints that input is strictly lowercase a–z
            // Handles greater range of characters than fixed array solution, but slightly slower due to dictionary overhead

            var (s, t) = (strings[0], strings[1]);
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t)) return false; // not valid use case per constraints
            if (s.Length != t.Length) return false;
            var lookup = new Dictionary<int, int>(); // accounts for unicode instead of Dictionary<char, int> but strings contain only a-z per problem constraints

            for (int i = 0; i < s.Length; i++)
            {
                lookup[s[i]] = lookup.GetValueOrDefault(s[i], 0) + 1;
                lookup[t[i]] = lookup.GetValueOrDefault(t[i], 0) - 1;
            }
            foreach (var kvp in lookup)
            {
                if (kvp.Value != 0) return false;
            }

            return true;
        }
    }
}