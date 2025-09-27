using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.RemoveElement
{
    [StrategyExport(
        ProblemType.RemoveElement,
        name: "O(n) - Two Pointer Swap",
        IsInPlace = true,
        HasDuplicates = false)]
    public class SwapWithEndPointerSolution : IProblemSolution<RemoveElementInput, int>
    {
        public int Solve(RemoveElementInput input)
        {

            //Submission: https://leetcode.com/problems/remove-element/submissions/1771072736/

            var (nums, target) = (input.Numbers, input.Target);

            //Analysis: 
            //array is unsorted, find and remove all instances of target in place, return new length (=>non-target element count)
            //two pointers - scanIx to scan for target, writeIx to swap duplicates in place with the right-most non-target element when match found

            //early pruning
            if (nums.Length < 1) return 0;
            if (nums.Length == 1) return nums[0] == target ? 0 : 1;

            int writeIx = nums.Length - 1;
            int scanIx = 0;

            for (; scanIx < nums.Length; scanIx++)
            {
                if (scanIx > writeIx) break; //pointers have crossed or met. Need to allow scanIx == writeIx to be processed. The swap logic already protects against unnecessary swaps when pointers meet
                while (nums[writeIx] == target && writeIx > scanIx) { writeIx--; }
                while (nums[scanIx] != target && scanIx < writeIx) { scanIx++; }
                if (nums[scanIx] == target) { (nums[writeIx], nums[scanIx]) = (nums[scanIx], nums[writeIx]); writeIx--; }
            }
            return writeIx + 1; //writeIx is last possible non-target element index
        }

    }
}