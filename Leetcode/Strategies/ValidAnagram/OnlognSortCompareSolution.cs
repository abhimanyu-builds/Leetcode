using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.ValidAnagram
{
    [StrategyExport(
        ProblemType.ValidAnagram,
        name: "O(nlogn) Sort in place and compare",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnlognSortCompareSolution : IProblemSolution<string[], bool>
    {
        public bool Solve(string[] strings)
        {

            // Submission: https://leetcode.com/problems/valid-anagram/submissions/1804675572/

            // Analysis:
            // If s or t is null or empty, return false — though this can't happen under the given constraints.
            // If lengths differ, they can't be anagrams — early exit.
            // Sort both strings and compare character by character.
            // Time: O(nlogn), Space: O(1)

            var (s, t) = (strings[0], strings[1]);
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t)) return false; // not valid use case per constraints
            if (s.Length != t.Length) return false;

            var sCharArray = s.ToCharArray();
            var tCharArray = t.ToCharArray();
            Array.Sort(sCharArray);
            Array.Sort(tCharArray);

            for (int i = 0; i < sCharArray.Length; i++)
            {
                if (sCharArray[i] != tCharArray[i]) return false;
            }

            return true;
        }
    }
}