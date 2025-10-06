using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.HillAndValleyCount
{
    [StrategyExport(
        ProblemType.HillAndValleyCount,
        name: "O(n) Plateau Collapse Linear Search",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnPlateauCollapseLinearSearchSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/count-hills-and-valleys-in-an-array/submissions/1792677158/
            //          https://leetcode.com/problems/count-hills-and-valleys-in-an-array/submissions/1792678533/

            //Analysis:
            // Linear search to find all local maxima and minima in one pass
            // Time Complexity: O(n), Space Complexity: O(n)
            // Empty array or single element or two elements - return 0
            // Collapse plateaus (deduplicate) into list of unique elements
            // At each step, compare element and its immediate neighbors to decide if current element is a peak or valley

            // early pruning for small arrays
            if (nums.Length < 3) return 0;     //single element or two elements - both sides constraint

            //prune duplicates (plateaus) by collapsing them into single elements
            List<int> pruned = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                    pruned.Add(nums[i]);
            }

            int hills = 0, valleys = 0;
            for (int i = 1; i < pruned.Count - 1; i++)
            {
                int left = pruned[i - 1], curr = pruned[i], right = pruned[i + 1];
                if (curr > left && curr > right) hills++;
                else if (curr < left && curr < right) valleys++;
            }
            return hills + valleys;
        }
    }
}