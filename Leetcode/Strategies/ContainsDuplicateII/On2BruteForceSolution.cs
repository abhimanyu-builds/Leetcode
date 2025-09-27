using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ContainsDuplicateII
{
    [StrategyExport(
        ProblemType.ContainsDuplicateII,
        name: "O(n²) Brute Force",
        IsInPlace = false,
        HasDuplicates = false)]
    public class On2BruteForceSolution : IProblemSolution<ContainsDuplicateInput, bool>
    {
        public bool Solve(ContainsDuplicateInput input)
        {

            //Submission: https://leetcode.com/problems/contains-duplicate-ii/submissions/1776614432/

            var (nums, k) = (input.Numbers, input.K);
            if (nums.Length <= 1 || k <= 0) return false;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j <= i + k && j < nums.Length; j++)
                {
                    if (nums[i] == nums[j]) { return true; }
                }
            }
            return false;
        }
    }
}