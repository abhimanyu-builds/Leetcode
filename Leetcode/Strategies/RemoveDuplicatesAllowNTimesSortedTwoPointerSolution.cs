using Leetcode.Interfaces;

namespace Leetcode.Strategies
{
    public class RemoveDuplicatesAllowNTimesSortedTwoPointerSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {
            //Submission: https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/submissions/1769981247
            //Analysis: 
            //array is sorted - in non-decreasing order.
            //two pointers to track unique elements and overwrite duplicates in place
            //generalize atmostLimit to be used for 1 (unique elements - remove duplicates from sorted array)
            int atmostLimit = 1;
            if (nums.Length <= atmostLimit) return nums.Length;

            int writeToIx = atmostLimit;
            for (int i = atmostLimit; i < nums.Length; i++)
            {
                if (nums[i] != nums[writeToIx - atmostLimit])
                {
                    nums[writeToIx] = nums[i];
                    writeToIx++;
                }
            }

            return writeToIx;
        }
    }
}