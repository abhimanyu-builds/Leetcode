using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.SearchInsertPosition
{
    [StrategyExport(
        ProblemType.SearchInsertPosition,
        name: "O(logn) Lower Bound Binary Search",
        IsInPlace = false,
        HasDuplicates = true)]
    public class OlognLowerBoundBinarySearchSolution : IProblemSolution<SearchInsertPositionInput, int>
    {
        public int Solve(SearchInsertPositionInput input)
        {

            //Submission: https://leetcode.com/problems/search-insert-position/submissions/1781814125/

            // Allows returning nums.Length if target is greater than all elements.
            // No equality check(nums[mid] == target) — this is intentional. Lower Bound doesn't care if the target is found; it returns the first position where it could be inserted
            // branchless even though it has a conditional, because both branches converge to the same assignment (left or right) - control flow is monotonic and doesn't short circuit

            var (nums, target) = (input.Numbers, input.Target);
            if (nums.Length == 0) return 0;
            int left = 0, right = nums.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }

            return left; // First index where nums[i] >= target

        }
    }
}