using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.MinStepsToAnagram
{
    [StrategyExport(
        ProblemType.MinStepsToAnagram,
        name: "O(n) Compute Frequency Delta",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnFrequencyDeltaSolution : IProblemSolution<string[], int>
    {
        public int Solve(string[] input)
        {

            //Submission: https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/submissions/1805279872/

            // Analysis:
            // Only t can be modified, so have to compute how many characters in t need to be replaced to match s.
            // Use a single frequency delta array: +1 for s, -1 for t at each index as problem constraints are lowercase letters only.
            // After processing both in single pass, positive values in delta represent excess characters in s that t lacks and must be matched by replacing a character in t.
            // Sum of positive deltas gives the minimum number of replacements needed.
            // No need to simulate actual replacements—just count the imbalance.
            // sorting and comparing positions doesn’t capture frequency imbalance as it assumes mismatches are symmetric and pairable, which isn’t always true


            var (s, t) = (input[0], input[1]);

            if (s == t) return 0;

            var delta = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                delta[s[i] - 'a']++;
                delta[t[i] - 'a']--;
            }

            int steps = 0;

            for (int i = 0; i < delta.Length; i++)
            {
                if (delta[i] > 0) steps += delta[i];
            }
            return steps;
        }
    }
}