using Leetcode.Interfaces;

namespace Leetcode.Strategies.LongestHarmoniousSubsequence
{
    public class OnFrequencyBasedSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/longest-harmonious-subsequence/submissions/1782832402/

            if (nums ==null || nums.Length == 0) return 0;
            Dictionary<int, int> seen = new();
            foreach(var num in nums)
            {
                seen.TryAdd(num, 0);
                seen[num]++;
            }
            int maxLen = 0;
            foreach(var key in seen.Keys)
            {
                if (seen.TryGetValue(key + 1, out int harmonic))
                {
                    maxLen = Math.Max(maxLen, harmonic + seen[key]);
                }
            }
            return maxLen;
        }
    }
}