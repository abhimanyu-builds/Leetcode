using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.MaxConsecutive1sIII
{
    [StrategyExport(
        ProblemType.MaxConsecutive1sIII,
        name: "O(n) Zero Index Queue",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnZeroIndexQueueSolution : IProblemSolution<MaxConsecutive1sIIIInput, int>
    {
        public int Solve(MaxConsecutive1sIIIInput input)
        {
            // Analysis:
            //   Use two pointers to define a sliding window [left, right].
            //   Track the indices of zeroes using a queue to manage flip budget.
            //   For each right:
            //       If nums[right] == 0 -> enqueue its index.
            //       While queue.Count > k:
            //           Dequeue the oldest zero index.
            //           Move left to one position after that index.
            //       Update maxCount with the current window size [right - left + 1].
            //   This ensures the window always contains at most k zeroes, which can be flipped.
            //   Edge case: if k == 0, window must shrink immediately on any zero.
            //   Edge case: if k >= nums.Length -> entire array can be flipped -> return nums.Length.

            //Submission: https://leetcode.com/problems/max-consecutive-ones-iii/submissions/1787560739/

            var (nums, k) = (input.Numbers, input.K.GetValueOrDefault());
            // Early edge-case pruning
            if (nums == null || nums.Length == 0) return 0;
            if (k >= nums.Length) return nums.Length; //can flip all

            int left = 0, maxCount = 0;
            Queue<int> zeroIndices = new Queue<int>();
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                    zeroIndices.Enqueue(right);
                if (zeroIndices.Count > k)
                {
                    left = zeroIndices.Dequeue() + 1;
                }
                maxCount = Math.Max(maxCount, right - left + 1); //zeros are included as they can be flipped as opposed to MaxConsecutive1s with 1 element *deleted*
            }

            return maxCount;
        }
    }
}