using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.GroupAnagrams
{
    [StrategyExport(
        ProblemType.GroupAnagrams,
        name: "O(n) Sort and Compare",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnklogkSortCompareSolution : IProblemSolution<string[], string[][]>
    {
        public string[][] Solve(string[] input)
        {

            // Submission: https://leetcode.com/problems/group-anagrams/submissions/1804719770/

            // Analysis:
            // For each string in input, compute a signature of sorted characters.
            // Strings with the same signature are grouped together in a dictionary.
            // At the end, collect all grouped anagram lists into a result array.
            // Time: O(n * k), where n = number of words, k = max word length
            // Space: O(n * k) for storing grouped words and their signatures
            // Assumes all input strings contain only lowercase English letters

            var anagramGroups = new Dictionary<string, List<string>>();

            for (int i = 0; i < input.Length; i++)
            {
                var sArr = input[i].ToCharArray();
                Array.Sort(sArr);
                var key = string.Join("", sArr);
                if (!anagramGroups.TryAdd(key, [input[i]]))
                {
                    anagramGroups[key].Add(input[i]);
                }
            }
            return anagramGroups.Values.Select(group => group.ToArray()).ToArray();

        }
    }
}