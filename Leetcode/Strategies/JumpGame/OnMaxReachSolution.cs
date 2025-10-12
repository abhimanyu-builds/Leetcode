using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.JumpGame
{
    [StrategyExport(
        ProblemType.JumpGame,
        name: "O(n) Max Reach",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnMaxReachSolution : IProblemSolution<int[], bool>
    {
        public bool Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/jump-game/submissions/1799583340/

            // Analysis:
            // Single-element arrays are trivially reachable => true
            // Empty arrays are trivially unreachable => false but are not a valid test case due to problem constraints
            // Jump length represents a maximum, not a fixed distance, so can jump to any element within jump length
            // A zero is only fatal if it blocks forward progress
            // Greedy invariant: if current index > maxReach => false
            // maxReach >= last index => true
            // Always starts from index 0 and propagate reach forward
            // Early jumps can unlock longer paths later
            // Edge cases like [3,2,1,0,4] expose traps where all paths funnel into a dead zone
            // Reachability is determined by whether any path allows maxReach to reach or exceed the last index

            //if (nums.Length == 1) return true;
            int i = 0;
            int maxReach = nums[i];

            while (i <= maxReach)
            {
                maxReach = Math.Max(maxReach, i + nums[i]);
                if (maxReach >= nums.Length - 1) return true;
                i++;
            }
            return false;
        }
    }
}