using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ValidMountainArray
{
    [StrategyExport(
        ProblemType.ValidMountainArray,
        name: "O(n) Single Pass Multiple Peak State Machine",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnSinglePassMultiplePeakStateSolution : IProblemSolution<int[], bool>
    {
        public bool Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/valid-mountain-array/submissions/1792290202/

            // Analysis:
            // nums.Length < 3 => false
            // first decreasing then increasing => false
            // equal elements => false
            // first increasing then only decreasing => true
            // track direction changes, if more than 1 => false

            if (nums.Length < 3) return false;
            int trendDirection = 0; // 0 = unset, 1 = increasing, -1 = decreasing
            int trendChangeCount = 0;
            int maxPeaks = 1;
            int maxTrendChanges = 2 * maxPeaks;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) return false; // plateau
                int currentDirection = nums[i - 1] > nums[i] ? -1 : 1;

                if (currentDirection == trendDirection) continue; // no change in direction

                trendChangeCount++;
                trendDirection = currentDirection;
                if (trendChangeCount > maxTrendChanges) return false;
            }

            return trendChangeCount == maxTrendChanges && trendDirection == -1;
        }
    }
}