using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ContainsDuplicateI
{
    [StrategyExport(
        ProblemType.ContainsDuplicateI,
        name: "O(n) Hashset",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnHashsetSolution : IProblemSolution<ContainsDuplicateInput, bool>
    {
        public bool Solve(ContainsDuplicateInput input)
        {

            //Submission: https://leetcode.com/problems/contains-duplicate/submissions/1775625750/

            var (nums, target) = (input.Numbers, input.Target);
            HashSet<int> seen = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(nums[i])) { return true; }
                seen.Add(nums[i]);
            }
            return false;
        }
    }
}