using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.JumpGame
{
    [StrategyExport(
        ProblemType.JumpGame,
        name: "O(n) Bottom Up DP",
        IsInPlace = false,
        HasDuplicates = false)]
    public class On2CanReachBottomUpDPSolution : IProblemSolution<int[], bool>
    {
        public bool Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/jump-game/submissions/1799584201/
            // Analysis:
            // Single-element arrays are trivially reachable => true
            // Empty arrays are invalid due to problem constraints
            // Jump length represents a maximum, not a fixed distance
            // Reachability is determined by whether any path allows maxReach to reach or exceed the last index
            // Build a canReach[] array from the end backwards
            // Mark index i as reachable if any forward jump from i lands on a reachable index
            // Time complexity: O(n^2) worst-case due to nested scan
            // Space complexity: O(n) for reachability table

            int n = nums.Length;
            bool[] canReach = new bool[n];
            canReach[n - 1] = true; // last index can reach itself
            for (int i = n - 2; i >= 0; i--)
            {
                //if (canReach[i]) continue; // already marked reachable but since canReach[i] is initialized to false and only updated once, this check is unnecessary unless reused in a loop with side effects

                int furthestJump = Math.Min(nums[i], n - 1 - i); // Limit jump to stay within array bounds
                for (int j = i + 1; j <= i + furthestJump; j++)
                {
                    if (canReach[j])
                    {
                        canReach[i] = true;
                        break;
                    }
                }
            }
            return canReach[0];
        }
    }
}