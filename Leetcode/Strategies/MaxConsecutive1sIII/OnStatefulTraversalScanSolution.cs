using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.MaxConsecutive1sIII
{
    [StrategyExport(
        ProblemType.MaxConsecutive1sIII,
        name: "O(n) Stateful Traversal",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnStatefulTraversalScanSolution : IProblemSolution<MaxConsecutive1sIIIInput, int>
    {
        public int Solve(MaxConsecutive1sIIIInput input)
        {
            //Submission:   https://leetcode.com/problems/max-consecutive-ones-iii/submissions/1787472668/
            //              https://leetcode.com/problems/max-consecutive-ones-iii/submissions/1787514922/

            var (nums, k) = (input.Numbers, input.K.GetValueOrDefault());

            // Analysis:
            //   Use two pointers to define a sliding window [left, right].
            //   Track zeroCount to count how many zeroes are in the current window.
            //   For each right:
            //       If nums[right] == 0 -> increment zeroCount.
            //       While zeroCount > k:
            //           Shrink window from the left until zeroCount ≤ k.
            //           If nums[left] == 0 -> decrement zeroCount.
            //           Increment left unconditionally to maintain window validity.
            //   After each iteration, update maxLength = right - left + 1.
            //   This ensures the window always contains at most k zeroes, which can be flipped.
            //   Edge case: if k == 0, window must shrink immediately on any zero.
            //   Edge case: if k >= nums.Length -> entire array can be flipped -> return nums.Length.


            //early edge-case pruning
            if (nums == null || nums.Length == 0) return 0;
            if (k >= nums.Length) return nums.Length; //can flip all

            int maxLength = 0;

            int left = 0, zeroCount = 0;
            //for (int right = 0; right < nums.Length; right++)
            //{
            //    if (nums[right] == 0) zeroCount++;
            //    while (zeroCount > k)
            //    {
            //        if (nums[left] == 0) zeroCount--;
            //        left++;
            //    }
            //    maxLength = Math.Max(maxLength, right - left + 1); //zeros are included as they can be flipped as opposed to MaxConsecutive1s with 1 element *deleted*
            //}

            int right = 0;
            while (right < nums.Length)
            {
                if (nums[right] == 0) zeroCount++;
                while (zeroCount > k)
                {
                    if (nums[left] == 0) zeroCount--;
                    left++;
                }
                maxLength = Math.Max(maxLength, right - left + 1); //zeros are included as they can be flipped as opposed to MaxConsecutive1s with 1 element *deleted*
                right++;
            }

            return maxLength;
        }

        private void Print(int[] nums, int left, int right, int zeroCount, int maxLength)
        {
            Console.Write($"\nWindow: [");
            //print array
            for (int i = left; i <= right; i++)
            {
                Console.Write(nums[i]);
            }
            Console.Write($"] Left: {left}, Right: {right}, ZeroCount: {zeroCount}, MaxLength: {maxLength}");
        }
    }
}
