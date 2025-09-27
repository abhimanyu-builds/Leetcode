using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.RotatedArrayII
{
    [StrategyExport(
        ProblemType.RotatedArray,
        name: "O(n) - Brute force linear search with duplicates",
        IsInPlace = false,
        HasDuplicates = true)]
    public class OnBruteForceSolution : IProblemSolution<RotatedArrayInput, int>
    {
        public int Solve(RotatedArrayInput input)
        {
            //Submission: https://leetcode.com/problems/search-in-rotated-sorted-array-ii/submissions/1774527204/

            (int[] nums, int target) = (input.Numbers, input.Target);

            //brute force solution O(n)
            //handles empty and single element arrays
            //used int instead of bool return type to use same interface as other strategies
            //skipping duplicates not needed as bool of match found is sufficient and first non-duplicate index isn't required
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) return i;
            }

            return -1;
        }
    }
}