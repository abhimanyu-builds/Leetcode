using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.HillAndValleyCount
{
    [StrategyExport(
        ProblemType.HillAndValleyCount,
        name: "O(n) Two-Pointer Linear Search",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnTwoPointerLinearSearchSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/count-hills-and-valleys-in-an-array/submissions/1792674567/

            //Analysis:
            // Linear search to find all local maxima and minima in one pass
            // Time Complexity: O(n), Space Complexity: O(1)
            // At each step, compare element and its immediate neighbors to decide if current element is a peak or valley
            // Empty array or single element or two elements - return 0
            // Have to use two pointers to handle plateaus (duplicates) rather than simple comparison
            // Skip duplicates (plateaus) by moving right pointer until a different element is found

            // early pruning for small arrays
            if (nums.Length < 3) return 0;     //single element or two elements - both sides constraint

            int hills = 0, valleys = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                int left = i - 1;
                int right = i + 1;
                
                while (right < nums.Length && nums[i] == nums[right]) { right++; continue; } //skip duplicates (plateau collapse)
                i = right - 1; //move i to the end of plateau
                if (right >= nums.Length) continue; // no right neighbor

                if (nums[left] < nums[i])
                {
                    if (nums[i] < nums[right]) { continue; } //ascending slope
                    else { hills++; } //peak
                }
                else if (nums[left] > nums[i])
                {
                    if (nums[i] > nums[right]) { continue; } //descending slope
                    else { valleys++; } //valley
                }
            }
            return hills + valleys;
        }
    }
}