using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ValidMountainArray
{
    [StrategyExport(
        ProblemType.ValidMountainArray,
        name: "O(n) Single Pass State Machine",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnSinglePassStateSolution : IProblemSolution<int[], bool>
    {
        public bool Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/valid-mountain-array/submissions/1792218528/

            // Analysis:
            // nums.Length < 3 => false
            // first decreasing then increasing => false
            // equal elements => false
            // first increasing then only decreasing => true
            // track direction changes, if more than 1 => false

            if (nums.Length < 3) return false;
            int trendDirection = 0; // 0 = unset, 1 = increasing, -1 = decreasing
            int trendChangeCount = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) return false; // plateau
                int currentDirection = nums[i - 1] > nums[i] ? -1 : 1;

                if (currentDirection == trendDirection) continue; // no change in direction

                trendChangeCount++;
                trendDirection = currentDirection;
                if (trendChangeCount > 2) return false;
            }

            return trendChangeCount == 2 && trendDirection == -1;
        }
    }
}