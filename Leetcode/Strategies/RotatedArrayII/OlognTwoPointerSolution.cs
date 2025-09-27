using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.RotatedArrayII
{
    [StrategyExport(
        ProblemType.RotatedArray,
        name: "O(logn) - Two Pointer Binary search solution with duplicates",
        IsInPlace = false,
        HasDuplicates = true)]
    public class OlognTwoPointerSolution : IProblemSolution<RotatedArrayInput, int>
    {
        public int Solve(RotatedArrayInput input)
        {
            //Submission: https://leetcode.com/problems/search-in-rotated-sorted-array-ii/submissions/1774568113/

            //Analysis:
            //array is sorted (non-descending) and rotated at some unknown pivot. may contain duplicates.
            //can do left,mid,right comparison to determine which side to search next.
            //left<mid doesn't always mean left is sorted, because of rotation. same with right>mid.
            //need to narrow the window with every pass, adjusting the pointers accordingly.
            //find which side of mid is sorted and which side of mid target falls in.
            //skipping duplicates with while loops with i and i+/-1 fails when left, mid, right are equal, can skip over the target if it's a duplicate.
            //Binary search thrives on minimal, predictable adjustments. only shrink bounds when progress can't be made.
            //Binary search assumes every element is either checked or safely excluded — skipping duplicates breaks that guarantee



            (int[] nums, int target) = (input.Numbers, input.Target);
            //nums = [4, 5, 6, 7, 0, 1, 2];
            //target = 0;//trivial case

            //early pruning
            if (nums.Length <= 1)
                return nums.Length == 1 && nums[0] == target ? 0 : -1;


            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                //In C#, declaring int mid inside the loop doesn’t allocate memory every time — it’s optimized by the compiler.
                //cleaner scope, avoid accidental use outside the loop

                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                if (nums[left] == nums[mid] && nums[right] == nums[mid])     // Ambiguous case: cannot determine sorted half due to duplicates
                {
                    left++;
                    right--;
                    continue;
                }

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