using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies.RemoveElement
{
    public class FwdPointerOverwriteSolution : IProblemSolution<RemoveElementInput, int>
    {
        public int Solve(RemoveElementInput input)
        {

            //Submission: https://leetcode.com/problems/remove-element/submissions/1771092182/

            var (nums, target) = (input.Numbers, input.Target);

            //Analysis: 
            //array is unsorted, find and remove all instances of target in place, return new length (=>non-target element count)
            //two pointers - scanIx and writeIx both start at 0, scans for target, overwrites when match found in place with the right-most non-target element when match found
            //scanIx gets incremented every loop, writeIx only when non-target found. 
            //overwrite element at writeIx with non-target element found at scanIx. same element if no target found yet. 

            //early pruning
            if (nums.Length < 1) return 0;
            if (nums.Length == 1) return nums[0] == target ? 0 : 1;

            int writeIx = 0, scanIx = 0;

            for (; scanIx < nums.Length; scanIx++)
            {
                if (nums[scanIx] != target)
                {
                    if (writeIx != scanIx) nums[writeIx] = nums[scanIx];   //overwrite starts after first match is found
                    writeIx++;
                }
            }

            return writeIx; //writeIx is last possible non-target element index + 1
        }

    }
}