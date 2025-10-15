using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.JumpGameIV
{
    [StrategyExport(
        ProblemType.JumpGameIV,
        name: "O(n) Node-Based BFS Queue with HashSet Visited",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnNodeBasedBFSWithHashSetVisitedSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/jump-game-iv/submissions/1802056411/

            // Analysis:
            // Empty arrays are invalid per constraints => no test case needed
            // Single-element arrays require zero jumps => return 0
            // Early pruning for arrays with 2 elements or same start/end value allow direct jump => return 1
            // Each move (hop or jump) costs 1 step
            // Visited set prevents cycles and redundant paths
            // Create BFS queue. DFS is least suited even when StackOverflow is not a concern (shortest path vs any path)
            // BFS explores all reachable indices level-by-level => all paths of length d are covered before any path of length d + 1 => First time reaching last index guarantees minimal steps
            // Construct value-to-index map for constant-time jump access - All indices with same value are reachable in same level
            // Clear value map after use to avoid exponential blowup
            // Need guard rails against out-of-bounds access and infinite loops
            // BFS explores  => first time the last index is reached, it’s guaranteed to be via the shortest path

            if (nums.Length <= 1) return 0;                         // Empty array invalid per constraints. Single-element array => already at last element, no jumps needed
            if (nums.Length == 2 || nums[0] == nums[^1]) return 1;  // Can jump directly to last element. Early pruning for same 1st and last element

            var freqLookup = new Dictionary<int, List<int>>();      // Frequency lookup to map values to their indices that can be jumped to at same level
            for (int i = 0; i < nums.Length; i++)
            {
                if (!freqLookup.TryAdd(nums[i], [i]))               // TryAdd (add if not exists = TryGetValue + Add) returns false if key already exists, then element is added to existing list.
                    freqLookup[nums[i]].Add(i);
            }

            var visited = new HashSet<int> { 0 };                                   // prevents infinite loops by guarding against re-visiting indices [1,2,1,2,1,2,1,2]

            var queue = new Queue<int[]>();
            queue.Enqueue([0, 0]);
            int jumps = 0;
            while (queue.TryDequeue(out var step))
            {
                int index = step[0];
                jumps = step[1];
                if (index == nums.Length - 1) return jumps;
                visited.Add(index);
                if (index - 1 >= 0 && visited.Add(index - 1))                       // guard against out-of-bounds access and infinite loops
                {
                    queue.Enqueue([index - 1, jumps + 1]);
                }
                if (index + 1 < nums.Length && visited.Add(index + 1))              // guard against out-of-bounds access and infinite loops
                {
                    queue.Enqueue([index + 1, jumps + 1]);
                }
                if (freqLookup.TryGetValue(nums[index], out List<int> indices))
                {
                    foreach (var nextIndex in indices)
                    {
                        if (nextIndex != index && visited.Add(nextIndex))
                        {
                            queue.Enqueue([nextIndex, jumps + 1]);                  // All equal value indices are reachable in one jump
                        }
                    }
                    freqLookup.Remove(nums[index]);                                 // Prevent future redundant processing
                }
            }

            return -1; // Should never happen per constraints, but safer


        }
    }
}