using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.SearchInsertPosition
{
    [StrategyExport(
        ProblemType.None,
        name: "O(logn) Lower Bound Binary Search",
        IsInPlace = false,
        HasDuplicates = true)]
    public class OlognExactOrInsertBinarySearchSolution : IProblemSolution<SearchInsertPositionInput, int>
    {
        public int Solve(SearchInsertPositionInput input)
        {

            //Submission: https://leetcode.com/problems/search-insert-position/submissions/1781813028/

            // returns any matching index, not necessarily the first.
            // To behave like lower bound when duplicates exist, search must continue left even after a match - this implementation does not do that. See HybridFirstMatchOrInsertBinarySearchSolution
            // fails when test cases expect first match behavior for duplicates

            var (nums, target) = (input.Numbers, input.Target);
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left; // Insert position if not found

        }
    }
}