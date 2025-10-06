using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.FindPeakElement
{
    [StrategyExport(
        ProblemType.FindPeakElement,
        name: "O(logn) Binary Search",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnLinearSearchSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/find-peak-element/submissions/1792634152/

            //Analysis:
            // Binary search to find the peak element in an array of potentially many peaks
            // Time Complexity: O(log n), Space Complexity: O(1)
            // At each step, check the mid element and its next neighbor to decide which half to continue searching in
            // If mid element is less than its next neighbor, the peak lies to the right (ascending slope)
            // If mid element is greater than its next neighbor, the peak lies to the left or is the mid element itself (descending slope or peak)
            // Loop invariant: At least one peak exists in the current search range [low, high]
            // Compare nums[mid] with nums[mid + 1] to determine slope direction:
            //  If nums[mid] < nums[mid + 1], we're on an ascending slope => peak lies to the right (mid isn't the peak so exclude mid)
            //  If nums[mid] > nums[mid + 1], we're on a descending slope or at a peak => peak lies to the left or at mid (mid maybe the peak so include mid)
            // Termination condition:  when low == high => that index is guaranteed to be a peak due to slope narrowing and strict inequality

            // early pruning for small arrays
            if (nums.Length == 0) return -1;    //invalid array
            if (nums.Length == 1) return 0;     //single element is peak - trivial case
            if (nums.Length == 2) return nums[0] > nums[1] ? 0 : 1; // two elements - return the larger one, either can be peak
            if (nums[0] > nums[1]) return 0;    // Check if the first element is peak for three or more elements
            if (nums[nums.Length - 1] > nums[nums.Length - 2]) return nums.Length - 1;  // Check if the last element is peak for three or more elements

            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < nums[mid + 1])
                    left = mid + 1; // Ascending slope
                else
                    right = mid;    // Descending slope or peak
            }

            return left; // or right, since left == right


        }
    }
}