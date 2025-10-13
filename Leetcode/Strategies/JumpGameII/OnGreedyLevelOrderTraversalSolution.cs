using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.JumpGameII
{
    [StrategyExport(
        ProblemType.JumpGameII,
        name: "O(n) Greedy Level Order Traversal",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnGreedyLevelOrderTraversalSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/jump-game-ii/submissions/1799801965/

            // Analysis:
            // Single-element arrays require zero jumps => return 0
            // Empty arrays are invalid per constraints => no test case needed
            // Jump length represents a maximum, not a fixed stride — can jump to any index within [i+1, i+nums[i]]
            // A zero is only problematic if it stalls progress before reaching the last index
            // Farthest reachable index is updated dynamically as we scan within the current jump window
            // Early jumps can unlock longer paths later — optimal path may not be locally obvious
            // Jump count is incremented only when we exhaust the current jump window (i == end). Forcing a jump early (just because you can reach the end) breaks the level-order invariant
            // maxReach >= n - 1 is guaranteed to be hit inside the loop, and handled naturally by the i == end condition. No need to force a break or increment early — it risks double-counting
            // Minimum jumps are determined by how many windows are traversed to reach or exceed the last index
            // The greedy algorithm is level-order: each jump window is a level
            // Time complexity: O(n) single pass through the array


            int maxReach = 0, end = 0;
            int jumps = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                maxReach = Math.Max(maxReach, i + nums[i]);

                if (i == end)
                {
                    jumps++;
                    end = maxReach;
                }
            }

            return jumps;
        }
    }
}