using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.LongestSubarrayAfterOneDeletion

{
    [StrategyExport(
        ProblemType.LongestSubarrayAfterOneDeletion,
        name: "O(n) Adjacent Block Merge (bridge over one gap)",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnAdjacentBlockMergeScanSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/submissions/1786797446/

            // Analysis: 
            // nums only contains 0s and 1s
            // if current number is 1, currentCount++
            // if current number is 0 and next number is 1, prevCount = currentCount, currentCount = 0 (bridge over one gap)
            // if current number is 0 and next number is 0, prevCount = 0, currentCount = 0 (reset both counts)
            // compute maxCount every iteration
            // adjust for edge case of all 1s at the end


            if (nums.Length == 0) return 0;    //edge case early pruning

            int prevCount = 0, currentCount = 0, maxCount = 0;
            bool seenZero = false;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) { currentCount++; } // streak continues
                else if (i + 1 < nums.Length && nums[i + 1] == 1) //streak broken but a new streak starts
                {
                    prevCount = currentCount;
                    currentCount = 0;
                    seenZero = true;
                }
                else
                {
                    prevCount = 0; // reset previous count if no adjacent block of 1s
                    currentCount = 0; // reset current count
                    seenZero = true;
                }
                maxCount = Math.Max(maxCount, currentCount + prevCount); // update max count
            }

            return !seenZero ? maxCount - 1 : maxCount;
        }
    }
}