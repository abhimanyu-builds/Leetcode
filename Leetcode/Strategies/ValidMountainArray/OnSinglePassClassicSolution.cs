using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ValidMountainArray
{
    [StrategyExport(
        ProblemType.ValidMountainArray,
        name: "O(n) Single Pass Classic Strict Walk",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnSinglePassClassicSolution : IProblemSolution<int[], bool>
    {
        public bool Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/valid-mountain-array/submissions/1792289127/

            // Analysis:
            // nums.Length < 3 => false
            // first decreasing then increasing => false
            // equal elements => false
            // first increasing then only decreasing => true
            // Walk up until peak is hit, then walk down, if end of array is reached => true

            if (nums.Length < 3) return false;
            int i = 0;
            while (i + 1 < nums.Length && nums[i] < nums[i + 1]) i++; // walk up
            if (i == 0 || i == nums.Length - 1) return false; // peak can't be first or last
            while (i + 1 < nums.Length && nums[i] > nums[i + 1]) i++; // walk down
            return i == nums.Length - 1;
        }
    }
}