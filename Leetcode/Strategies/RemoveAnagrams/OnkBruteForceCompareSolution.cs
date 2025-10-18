using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.RemoveAnagrams
{
    [StrategyExport(
        ProblemType.RemoveSequentialAnagrams,
        name: "O(n) Brute Force Sort and Compare",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnkBruteForceCompareSolution : IProblemSolution<string[], string[]>
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


            var result = new List<string>() { input[0] };

            for (int i = 1; i < input.Length; i++)
            {
                bool isAnagram = AreAnagrams(input[i], input[i - 1]);
                if (!isAnagram)
                {
                    result.Add(input[i]);
                }
            }
            return [.. result];
        }
        private static bool AreAnagrams(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            var arr1 = s1.ToCharArray();
            var arr2 = s2.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }
    }
}