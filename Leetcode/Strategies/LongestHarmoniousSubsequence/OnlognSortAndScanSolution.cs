using Leetcode.Interfaces;

namespace Leetcode.Strategies.LongestHarmoniousSubsequence
{
    public class OnlognSortScanSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/longest-harmonious-subsequence/submissions/1782848864/

            if (nums == null || nums.Length == 0) return 0;

            Array.Sort(nums);
            int maxLen = 0, prevCount = 0, prevValue = int.MinValue;
            for (int i = 0; i < nums.Length;)
            {
                int currentValue = nums[i];
                int currentCount = 0;
                while (i < nums.Length && nums[i] == currentValue) { currentCount++; i++; }

                if (currentValue == prevValue + 1)
                {
                    maxLen = Math.Max(maxLen, prevCount + currentCount);
                }
                prevValue = currentValue;
                prevCount = currentCount;
            }
            return maxLen;
        }
    }
}