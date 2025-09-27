using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.RotatedArray
{
    [StrategyExport(
        ProblemType.RotatedArray,
        name: "O(n) - Brute force linear search",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnBruteForceSolution : IProblemSolution<RotatedArrayInput, int>
    {
        public int Solve(RotatedArrayInput input)
        {
            //Submission: https://leetcode.com/problems/search-in-rotated-sorted-array/submissions/1773391174

            (int[] nums, int target) = (input.Numbers, input.Target);

            //brute force solution O(n)
            //handles empty and single element arrays
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) return i;
            }

            return -1;
        }
    }
}