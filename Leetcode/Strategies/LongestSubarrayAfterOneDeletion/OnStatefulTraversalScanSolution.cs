using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.LongestSubarrayAfterOneDeletion

{
    [StrategyExport(
        ProblemType.LongestSubarrayAfterOneDeletion,
        name: "O(n) Stateful Traversal Sliding Window",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnStatefulTraversalScanSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {
            //Submission: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/submissions/1784945168/

            // Analysis: 
            // nums only contains 0s and 1s
            // Exactly one number can be deleted, and it can be any number, not necessarily a 0
            // Deletion need not always occur within the block, deletion of a surrounding zero is allowed. e.g., [0,1,1,1,1,1,0] -> 5
            // If array contains only 1s, one element must still be deleted -> result is length - 1
            // EXACTLY 1 element must be deleted => at least one non-1 element, at most one non-1 element in the longest subarray of 1s (to delete)
            // Goal: Find the longest contiguous subarray of 1s after deleting one element => *Find longest subarray of 1s with at most one 0*.
            // Sliding window with two pointers, left and right, and a count of 0s in the current window.

            if (nums.Length == 0) return 0;    //edge case early pruning

            int maxLength = 0, left = 0, zeroCount = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }

                while (zeroCount > 1)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;                    //protects against violating "delete exactly one element" rule
                    }
                    left++;                             // shrinks window until we have at most one 0 in the window
                }
                // Measures the longest 1s-only subarray achievable by deleting one element.
                maxLength = Math.Max(maxLength, right - left);
            }

            return maxLength;


            //if (nums.Length == 0) return 0;
            //int prevOnes = 0, currOnes = 0, maxLength = 0;
            //bool seenZero = false;


            //foreach (int num in nums)
            //{
            //    if (num == 1)
            //    {
            //        currOnes++;
            //    }
            //    else
            //    {
            //        seenZero = true;
            //        maxLength = Math.Max(maxLength, prevOnes + currOnes);
            //        prevOnes = currOnes;
            //        currOnes = 0;
            //    }
            //}

            //maxLength = Math.Max(maxLength, prevOnes + currOnes);

            //// Must delete one element
            //return seenZero ? maxLength : maxLength - 1;

            //int n = nums.Length;
            //if (n == 0) return 0;

            //int[] left = new int[n];
            //int[] right = new int[n];

            //// Build left scan: number of consecutive 1s ending at i
            //left[0] = nums[0];
            //for (int i = 1; i < n; i++)
            //    left[i] = nums[i] == 1 ? left[i - 1] + 1 : 0;

            //// Build right scan: number of consecutive 1s starting at i
            //right[n - 1] = nums[n - 1];
            //for (int i = n - 2; i >= 0; i--)
            //    right[i] = nums[i] == 1 ? right[i + 1] + 1 : 0;

            //int maxLength = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    // Delete nums[i], combine left[i - 1] and right[i + 1]
            //    int leftPart = i > 0 ? left[i - 1] : 0;
            //    int rightPart = i < n - 1 ? right[i + 1] : 0;
            //    maxLength = Math.Max(maxLength, leftPart + rightPart);
            //}

            //return maxLength;

            //int maxLength = 0;
            //int prev = -1; // previous zero index
            //int last = -1; // last zero index
            //int count = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == 0)
            //    {
            //        if (prev != -1)
            //            maxLength = Math.Max(maxLength, i - prev - 1);
            //        prev = last;
            //        last = i;
            //    }
            //}

            //// Final stretch
            //if (prev != -1)
            //    maxLength = Math.Max(maxLength, nums.Length - prev - 1);
            //else
            //    maxLength = nums.Length - 1; // all 1s, must delete one

            //return maxLength;

            //int max = 0;
            //int prev = -1; // length of previous 1s block
            //int curr = 0;  // length of current 1s block
            //bool seenZero = false;

            //foreach (int num in nums)
            //{
            //    if (num == 1)
            //    {
            //        curr++;
            //    }
            //    else
            //    {
            //        seenZero = true;
            //        max = Math.Max(max, prev + curr);
            //        prev = curr;
            //        curr = 0;
            //    }
            //}

            //max = Math.Max(max, prev + curr);
            //return seenZero ? max : max - 1;


        }
    }
}