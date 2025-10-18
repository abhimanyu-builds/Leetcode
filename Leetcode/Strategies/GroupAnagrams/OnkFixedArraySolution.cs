using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.GroupAnagrams
{
    [StrategyExport(
        ProblemType.GroupAnagrams,
        name: "O(n) Dictionary with Fixed Array Signature",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnkFixedArraySolution : IProblemSolution<string[], string[][]>
    {
        public string[][] Solve(string[] input)
        {

            // Submission: https://leetcode.com/problems/group-anagrams/submissions/1804720451/

            // Analysis:
            // For each string in input, compute a signature based on character frequency using a fixed-size array (26 slots for 'a'–'z').
            // The signature is a string like "1.0.2.0..." representing counts of each letter, joined with delimiters to avoid collisions.
            // Words with the same signature are grouped together in a dictionary.
            // At the end, collect all grouped anagram lists into a result array.
            // Time: O(n * k), where n = number of words, k = max word length
            // Space: O(n * k) for storing grouped words and their signatures
            // Assumes all input strings contain only lowercase English letters
            // Signature is delimiter-safe to prevent false positives from ambiguous frequency patterns

            var groups = new Dictionary<string, List<string>>();
            for (int i = 0; i < input.Length; i++)
            {
                string signature = GetSignature(input[i]);
                if (!groups.TryAdd(signature, [input[i]]))
                {
                    groups[signature].Add(input[i]);
                }
            }
            var result = new List<string[]>();
            foreach (var kvp in groups)
            {
                result.Add([.. kvp.Value]);
            }
            return [.. result];
        }
        private static string GetSignature(string s)
        {
            var freq = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 'a']++;
            }
            return string.Join(".", freq);
        }
    }
}