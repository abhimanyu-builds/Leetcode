using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.LongestHarmoniousSubsequence
{
    [StrategyExport(
        ProblemType.LongestHarmoniousSubsequence,
        name: "O(n) Frequency based",
        IsInPlace = false,
        HasDuplicates = true)]
    public class OnFrequencyBasedSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            Dictionary<int, int> seen = new();
            foreach (var num in nums)
            {
                seen.TryAdd(num, 0);
                seen[num]++;
            }

            int maxLen = 0;
            foreach (var key in seen.Keys)
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