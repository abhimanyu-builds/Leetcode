using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.RemoveAnagrams
{
    [StrategyExport(
        ProblemType.RemoveSequentialAnagrams,
        name: "O(n) Sort and Compare",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnklogkSortCompareSolution : IProblemSolution<string[], string[]>
    {
        public string[] Solve(string[] input)
        {

            // Submission: https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/submissions/1805071872/

            // Analysis:
            // Assumes all input strings contain only lowercase English letters
            // Assumes input is sorted such that anagrams are adjacent.
            // For each string, compute a signature by sorting its characters.
            // If the signature differs from the previous one, keep the string.
            // Time: O(n * klogk), where n = number of strings, k = max string length
            // Space: O(n * k) for storing remaining strings

            var result = new List<string>();
            string prevString = string.Empty;
            foreach (var s in input)
            {
                var arr = s.ToCharArray();
                Array.Sort(arr);
                var sortedString = string.Join("", arr);
                if (sortedString != prevString)
                {
                    result.Add(s);
                    prevString = sortedString;
                }
            }

            return [.. result];
        }
    }
}