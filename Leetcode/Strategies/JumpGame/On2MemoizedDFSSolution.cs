using Leetcode.Interfaces;
using Leetcode.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Leetcode.Strategies.JumpGame
{
    [StrategyExport(
        ProblemType.JumpGame,
        name: "O(n) Memoized DFS",
        IsInPlace = false,
        HasDuplicates = false)]
    public class On2MemoizedDFSSolution : IProblemSolution<int[], bool>
    {
        public bool Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/jump-game/submissions/1799598972/

            // Analysis:
            // Single-element arrays are trivially reachable => true
            // Empty arrays are trivially unreachable => false but are not a valid test case due to problem constraints
            // Jump length represents a maximum, not a fixed distance, so can jump to any element within jump length
            // Reachability is determined by whether any path allows maxReach to reach or exceed the last index
            // Recursively explore reachability and cache results in a memo array to avoid recomputation
            // Mark positions as reachable if any forward jump from them lands on a reachable index
            // Time complexity: O(n^2) worst-case due to nested recursion
            // Space complexity: O(n) for memo table and recursion stack

            var memo = new bool?[nums.Length];

            return CanReachFromPosition(0, nums, memo);
        }
        private bool CanReachFromPosition(int i, int[] nums, bool?[] memo)
        {
            if (i >= nums.Length - 1) return true; // reached the end
            if (memo[i].HasValue) return memo[i].Value; // already marked reachable
            int furthestJump = Math.Min(i + nums[i], nums.Length - 1);  // Limit jump to stay within array bounds
            for (int j = i + 1; j <= furthestJump; j++)
            {
                if (CanReachFromPosition(j, nums, memo))
                {
                    memo[i] = true;
                    return true;
                }
            }
            memo[i] = false;
            return false;
        }
    }
}