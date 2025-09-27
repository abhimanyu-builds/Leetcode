using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ThreeSum
{
    [StrategyExport(
        ProblemType.ThreeSum,
        name: "O(n^2) - Sorting + Two-pointer",
        IsInPlace = false,
        HasDuplicates = false)]
    public class On2SortingTwoPointerSolution : IProblemSolution<ThreeSumInput, List<List<int>>>
    {
        public List<List<int>> Solve(ThreeSumInput input)
        {
            //Submission: https://leetcode.com/problems/3sum/submissions/1767857695/

            // Analysis:
            // The array can contain negative, zero, and positive numbers in any order. need to sort for this strategy
            // The goal is to find all unique triplets that sum to a given target (usually 0).
            // No need to return indices—just the actual values. Order doesn't matter so will sort triplet before adding to result to avoid duplicates.
            // Uniqueness isn't explicitly required, but it's enforced to avoid duplicate sets.

            // Approach:
            // Sort the array.
            // Use a single loop to fix one element, then apply the two-pointer technique to find pairs that when added to the fixed element equals target.
            // Skip duplicates if consecutive values are the same in two-pointer search. This excludes the fixed element which can be equal to the next element. (-x,-x,2x) is not skipped if current = -x.

            // Triplets are tracked using a HashSet to enforce uniqueness.

            var (nums, target) = (input.Numbers, input.Target);
            //trivial case target=0;

            //Early pruning strategy: if not enough numbers in array, or all numbers are positive and target is non-positive, or all negative and target is non-negative, no valid triplet exists.
            if (nums == null || nums.Count < 3) return new List<List<int>>();

            bool hasNegative = false;
            bool hasPositive = false;
            bool hasTarget = false; // for symmetric pairs
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0) { hasNegative = true; }
                if (nums[i] > 0) { hasPositive = true; }
                if (nums[i] == target) hasTarget = true;
                if (hasTarget && hasNegative && hasPositive) break;
            }
            if (!hasNegative && !hasTarget && target <= 0) return new List<List<int>>();
            if (!hasPositive && !hasTarget && target >= 0) return new List<List<int>>();

            nums.Sort();    //O(n log n) average

            List<List<int>> result = new();
            HashSet<string> seen = new();

            for (int i = 0; i < nums.Count - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // skip duplicates
                int current = nums[i];
                if (current > target && current >= 0) break; // early exit. sorted array, so no further triplets possible
                long sum = (long)current + nums[i + 1] + nums[i + 2];
                if (sum > target) break; // early exit. smallest possible triplet exceeds target
                int left = i + 1, right = nums.Count - 1;
                while (left < right)
                {
                    sum = (long)current + nums[left] + nums[right];
                    if (sum == target)
                    {
                        var triplet = new List<int> { current, nums[left], nums[right] };
                        var tripletSignature = $"{triplet[0]}:{triplet[1]}:{triplet[2]}";
                        if (!seen.Contains(tripletSignature))
                        {
                            seen.Add(tripletSignature);
                            result.Add(triplet);
                        }
                        left++;
                        right--;
                        while (left < right && nums[left] == nums[left - 1]) left++; // skip duplicates
                        while (left < right && nums[right] == nums[right + 1]) right--; // skip duplicates
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }
    }
}