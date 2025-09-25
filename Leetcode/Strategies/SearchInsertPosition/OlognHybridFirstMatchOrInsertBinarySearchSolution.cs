using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies.SearchInsertPosition
{
    public class OlognHybridFirstMatchOrInsertBinarySearchSolution : IProblemSolution<SearchInsertPositionInput, int>
    {
        public int Solve(SearchInsertPositionInput input)
        {
            // Hybrid lower-bound-aware binary search
            // Explicitly tracks the first index where nums[i] >= target. Continues searching left even after match is found, ensuring first match behavior.

            // Submission: https://leetcode.com/problems/search-insert-position/submissions/1781818244/

            var (nums, target) = (input.Numbers, input.Target);
            int left = 0, right = nums.Length - 1, result = nums.Length;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] >= target)
                {
                    result = mid; // potential insert or first match
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }

            return result;

        }
    }
}