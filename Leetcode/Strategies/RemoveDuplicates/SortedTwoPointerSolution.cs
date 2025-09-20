using Leetcode.Interfaces;

namespace Leetcode.Strategies.RemoveDuplicates
{
    public class SortedTwoPointerSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/remove-duplicates-from-sorted-array/submissions/1768813001/

            //Analysis: 
            //array is sorted - in non-decreasing order.
            //we can use two pointers to track unique elements and overwrite duplicates in place.

            //early pruning
            if (nums.Length < 2) return nums.Length;

            int writeToIx = 1;
            int lastUniqueNum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == lastUniqueNum) continue;

                nums[writeToIx] = nums[i];
                lastUniqueNum = nums[i];
                writeToIx++;
            }

            return writeToIx;

        }
    }
}