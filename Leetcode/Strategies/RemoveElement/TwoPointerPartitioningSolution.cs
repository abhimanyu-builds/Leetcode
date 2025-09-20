using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies.RemoveElement
{
    public class TwoPointerPartitioningSolution : IProblemSolution<RemoveElementInput, int>
    {
        public int Solve(RemoveElementInput input)
        {

            //Submission: https://leetcode.com/problems/remove-element/submissions/1771106546/

            var (nums, target) = (input.Numbers, input.Target);

            //Analysis: 
            //array is unsorted, find and remove all instances of target in place, return new length (=>non-target element count)
            //two pointers - scanIx to scan for target, writeIx to replace scanIx element in place when match found;
            // writeIx may initially point to a target value. to ensure correct partitioning, targets at the end must be skipped over before using writeIx as a source for overwriting scanIx.
            //scanIx not incrementing when match found ensures every element is processed, including those swapped in from the end of the array, which may also be target elements
            //right marks the end of the valid region, a boundary marker. Everything beyond right is considered garbage or removed

            //early pruning
            if (nums.Length < 1) return 0;
            if (nums.Length == 1) return nums[0] == target ? 0 : 1;

            int writeIx = nums.Length - 1;
            int scanIx = 0;

            while (scanIx <= writeIx)
            {
                if (nums[scanIx] == target)
                {
                    while (writeIx > scanIx && nums[writeIx] == target)     // to skip over targets to keep partitioning correct
                        writeIx--;

                    if (scanIx >= writeIx) break;

                    nums[scanIx] = nums[writeIx];
                    writeIx--;
                }
                else
                {
                    scanIx++;
                }
            }

            return scanIx; //writeIx is last possible non-target element index
        }

    }
}