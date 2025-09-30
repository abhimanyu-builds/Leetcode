using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.LongestSubarrayAfterOneDeletion

{
    [StrategyExport(
        ProblemType.LongestSubarrayAfterOneDeletion,
        name: "O(n) Prefix + Suffix scan",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnPrefixSuffixSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/submissions/1786809763/

            // Analysis: 
            // nums only contains 0s and 1s
            // note length of streak of 1s before current number in prefix array
            // note length of streak of 1s after current number in suffix array
            // find max(prefix[i-1] + suffix[i+1]) for every 0 and return max
            // adjust for edge case of all 1s at the end - must delete one element

            if (nums.Length == 0) return 0;    //edge case early pruning

            int[] prefix = new int[nums.Length];
            int[] suffix = new int[nums.Length];
            bool seenZero = false;

            prefix[0] = nums[0];
            suffix[nums.Length - 1] = nums[nums.Length - 1];

            // build prefix array
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    prefix[i] = prefix[i - 1] + 1;
                }
                else
                {
                    prefix[i] = 0;
                    seenZero = true;
                }
            }

            // build suffix array
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] == 1)
                {
                    suffix[i] = suffix[i + 1] + 1;
                }
                else
                {
                    suffix[i] = 0;
                    seenZero = true;
                }
            }
            int maxCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    int leftCount = i > 0 ? prefix[i - 1] : 0;
                    int rightCount = i < nums.Length - 1 ? suffix[i + 1] : 0;
                    maxCount = Math.Max(maxCount, leftCount + rightCount);
                }
            }

            return !seenZero ? nums.Length - 1 : maxCount;
        }
    }
}