using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.JumpGameIV
{
    [StrategyExport(
        ProblemType.JumpGameIV,
        name: "O(n) Level-Based BFS With Bool array Visited",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnLevelBasedBFSWithBoolVisitedSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            // Submission: https://leetcode.com/problems/jump-game-iv/submissions/1802117233/

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

            var freqLookup = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!freqLookup.TryAdd(nums[i], [i]))
                {
                    freqLookup[nums[i]].Add(i);
                }
            }

            var queue = new Queue<int>();
            var visited = new bool[nums.Length];
            queue.Enqueue(0);
            visited[0] = true;
            int steps = 0;

            while (queue.Count > 0)                                         //essentially to increment steps after processing all nodes at current level
            {
                for (int i = queue.Count; i > 0; i--)
                {
                    int current = queue.Dequeue();
                    if (current == nums.Length - 1) return steps;

                    if (current + 1 < nums.Length && !visited[current + 1]) //guard against out-of-bounds and only enqueue unvisited indices to prevent infinite loops
                    {
                        visited[current + 1] = true;
                        queue.Enqueue(current + 1);
                    }
                    if (current - 1 >= 0 && !visited[current - 1])           //guard against out-of-bounds and only enqueue unvisited indices to prevent infinite loops
                    {
                        visited[current - 1] = true;
                        queue.Enqueue(current - 1);
                    }

                    if (freqLookup.TryGetValue(nums[current], out List<int> indices))
                    {
                        foreach (int neighbor in indices)
                        {
                            if (!visited[neighbor])                          //guard against out-of-bounds and only enqueue unvisited indices to prevent infinite loops
                            {
                                visited[neighbor] = true;
                                queue.Enqueue(neighbor);
                            }
                        }
                    }
                    freqLookup.Remove(nums[current]);
                }
                steps++;
            }

            return -1;
        }
    }
}