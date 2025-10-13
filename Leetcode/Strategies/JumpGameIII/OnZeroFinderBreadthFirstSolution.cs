using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.JumpGameIII
{
    [StrategyExport(
        ProblemType.JumpGameIII,
        name: "O(n) Breadth First",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnZeroFinderBreadthFirstSolution : IProblemSolution<JumpGameIIIInput, bool>
    {
        public bool Solve(JumpGameIIIInput input)
        {
            // Submission: https://leetcode.com/problems/jump-game-iii/submissions/1800785478/

            // Analysis:
            // Starting position is given
            // From any position i, you can jump to i + nums[i] or i - nums[i] => can't jump to both, you can choose one of the two | can't jump to any position in between
            // arr[i] > 0 per problem constraints
            // if nums[i] == 0, the target is reached
            // Set guardrails to avoid infinite loops and to avoid jumping out of bounds
            // Create an array of size nums.Length to track visited indices
            // Use a queue to explore positions in breadth-first manner
            // Time: O(n) - each index is visited at most once

            var (nums, start) = (input.Numbers, input.Target);

            if (nums == null || nums.Length == 0 || start < 0 || start >= nums.Length) return false; // edge case

            var visited = new bool[nums.Length];
            var queue = new Queue<int>();

            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();

                int jump = nums[i];
                if (jump == 0) return true; // found 0

                if (visited[i]) continue; // already visited

                int forward = i + jump;
                if (forward < nums.Length) queue.Enqueue(forward);
                int backward = i - jump;
                if (backward >= 0) queue.Enqueue(backward);

                visited[i] = true; // mark as visited
            }
            return false;
        }
    }
}