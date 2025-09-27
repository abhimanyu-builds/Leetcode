using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ContainsDuplicateI
{
    [StrategyExport(
        ProblemType.ContainsDuplicateI,
        name: "O(nlogn) Sort + Scan",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnlognSortScanSolution : IProblemSolution<ContainsDuplicateInput, bool>
    {
        public bool Solve(ContainsDuplicateInput input)
        {

            //Submission: Timed out on larger inputs

            var (nums, target) = (input.Numbers, input.Target);
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) { return true; }
            }
            return false;
        }
    }
}