using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.JumpGameIII
{
    [StrategyExport(
        ProblemType.JumpGameIII,
        name: "O(n) Hybrid - Breadth First or Depth First based on input size",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnZeroFinderHybridSolution : IProblemSolution<JumpGameIIIInput, bool>
    {
        public bool Solve(JumpGameIIIInput input)
        {
            // Submission: https://leetcode.com/problems/jump-game-iii/submissions/1800794007/

            // Analysis:
            // Starting position is given
            // From any position i, you can jump to i + nums[i] or i - nums[i] => can't jump to both, you can choose one of the two | can't jump to any position in between
            // arr[i] > 0 per problem constraints
            // if nums[i] == 0, the target is reached
            // Set guardrails to avoid infinite loops and to avoid jumping out of bounds
            // Create an array of size nums.Length to track visited indices
            // For small arrays, use depth-first recursion with memoization to minimize overhead
            // Use a queue to explore positions in breadth-first manner for large arrays
            // Time: O(n) - each index is visited at most once

            var (nums, start) = (input.Numbers, input.Target);

            if (nums == null || nums.Length == 0 || start < 0 || start >= nums.Length) return false; // edge case


            int switchThreshold = 1000; // empirical threshold to switch between DFS and BFS

            if (nums.Length <= switchThreshold)
            {
                return CanReachZeroDFS(nums, start);
            }
            else
            {
                return CanReachZeroBFS(nums, start);
            }
        }

        private bool CanReachZeroBFS(int[] nums, int start)
        {
            if (start < 0 || start >= nums.Length) return false; // edge case

            var visited = new bool[nums.Length];
            var queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                if (visited[i]) continue; // already visited

                int jump = nums[i];
                if (jump == 0) return true; // found 0

                if (i + jump < nums.Length) queue.Enqueue(i + jump);
                if (i - jump >= 0) queue.Enqueue(i - jump);

                visited[i] = true; // mark as visited

            }
            return false;
        }

        private bool CanReachZeroDFS(int[] nums, int position, bool?[]? visited = null)
        {
            if (visited == null) visited = new bool?[nums.Length];
            if (position < 0 || position >= nums.Length) return false; // out of bounds
            if (visited[position].HasValue) return visited[position].Value; // already visited
            visited[position] = false; // mark as visited. updated with actual result after recursion. *If visited marking is delayed until after recursion, cyclic paths can recurse infinitely before memoization kicks in, leading to StackOverflowException*
            int jump = nums[position];
            if (jump == 0) return true;
            bool canReach = CanReachZeroDFS(nums, position + jump, visited) || CanReachZeroDFS(nums, position - jump, visited);
            visited[position] = canReach;
            return canReach;
        }
    }
}