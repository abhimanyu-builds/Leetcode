using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.RemoveAnagrams
{
    [StrategyExport(
        ProblemType.RemoveSequentialAnagrams,
        name: "O(n) Dictionary with Fixed Array Signature",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnkFixedArraySolution : IProblemSolution<string[], string[]>
    {
        public string[] Solve(string[] input)
        {

            // Submission: https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/submissions/1805071172/

            // Analysis:
            // Assumes input is sorted such that anagrams are adjacent.
            // For each string, compute a frequency-based signature using a fixed-size array (26 slots for 'a'–'z').
            // The signature is a string like "1.0.2.0..." representing counts of each letter, joined with delimiters to avoid collisions.
            // Strings with the same signature as previous string can be discarded.
            // Time: O(n * k), where n = number of words, k = max word length
            // Space: O(n * k) for storing grouped words and their signatures
            // Assumes all input strings contain only lowercase English letters

            var result = new List<string>();

            string prevSignature = string.Empty;

            foreach (string s in input)
            {
                string signature = GetSignature(s);
                if (signature != prevSignature)
                {
                    result.Add(s);
                    prevSignature = signature;
                }
            }

            return [.. result];
        }
        private static string GetSignature(string s)
        {
            var freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }
            return string.Join(".", freq);
        }
    }
}