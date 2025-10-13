using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.JumpGameIII
{
    [StrategyExport(
        ProblemType.JumpGameIII,
        name: "O(n) Depth First",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnZeroFinderDepthFirstSolution : IProblemSolution<JumpGameIIIInput, bool>
    {
        public bool Solve(JumpGameIIIInput input)
        {
            // Submission: https://leetcode.com/problems/jump-game-iii/submissions/1800773145/

            // Analysis:
            // Starting position is given
            // From any position i, you can jump to i + nums[i] or i - nums[i] => can't jump to both, you can choose one of the two | can't jump to any position in between
            // arr[i] > 0 per problem constraints
            // if nums[i] == 0, the target is reached. if nums[start] == 0, return true - early exit
            // Set guardrails to avoid infinite loops and to avoid jumping out of bounds
            // Create an array of size nums.Length to track visited indices
            // Time: O(n) - each index is visited at most once
            // Will fail with StackOverflowException if recursion depth exceeds stack limit (e.g. very large array with long path to zero) 

            var (nums, start) = (input.Numbers, input.Target);
            if (nums == null || nums.Length == 0 || start < 0 || start >= nums.Length) return false; // edge case

            var visited = new bool?[nums.Length];

            return CanReachZero(nums, start, visited);
        }
        private bool CanReachZero(int[] nums, int position, bool?[] visited)
        {
            if (position < 0 || position > nums.Length - 1) return false; // out of bounds
            if (visited[position].HasValue) return visited[position].Value; // already visited

            int jump = nums[position];
            if (jump == 0) return true; // found 0

            visited[position] = false; // mark as visited. updated with actual result after recursion. *If visited marking is delayed until after recursion, cyclic paths can recurse infinitely before memoization kicks in, leading to StackOverflowException*

            bool canReach = CanReachZero(nums, position + jump, visited) || CanReachZero(nums, position - jump, visited);

            visited[position] = canReach; // memoize result
            return canReach;
        }
    }
}