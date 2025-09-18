using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies
{
    public class RotatedArrayOlognTwoPointerSolution : IProblemSolution<RotatedArrayInput, int>
    {
        public int Solve(RotatedArrayInput input)
        {
            //Submission: https://leetcode.com/problems/search-in-rotated-sorted-array/submissions/1774500104/

            //Analysis:
            //array is sorted (non-descending) and rotated at some unknown pivot.
            //right can't be greater than left in rotated array
            //can do left,mid,right comparison to determine which side to search next.
            //left<mid doesn't always mean left is sorted, because of rotation. same with right>mid.
            //need to narrow the window with every pass, adjusting the pointers accordingly.
            //find which side of mid is sorted and which side of mid target falls in.
            //example: [4,5,6,7,0,1,2], target=0
            //example: [6,7,0,1,2,4,5], target=0
            (int[] nums, int target) = (input.Numbers, input.Target);
            //nums = [4, 5, 6, 7, 0, 1, 2];
            //target = 0;//trivial case

            //early pruning
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;


            int left = 0, mid = 0, right = nums.Length - 1;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                if (nums[left] <= nums[mid])                                 //left to mid is sorted
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else                                                        //mid to right is sorted
                {
                    if (nums[mid] < target && target <= nums[right])        //target lies between mid and right
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;          //no solution, unreachable due to problem conditions

        }
    }
}