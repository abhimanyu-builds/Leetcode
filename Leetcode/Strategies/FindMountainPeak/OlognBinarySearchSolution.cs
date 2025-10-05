using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.FindMountainPeak
{
    [StrategyExport(
        ProblemType.FindMountainPeak,
        name: "O(logn) Lower Bound Binary Search",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OlognBinarySearchSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] arr)
        {

            //Submission: https://leetcode.com/problems/peak-index-in-a-mountain-array/submissions/1792471817/

            //Analysis:
            // Binary search to find the peak element in a mountain array
            // Time Complexity: O(log n), Space Complexity: O(1)
            // Leverages the property of the mountain array (assured by problem constraints) to determine the direction of the peak
            // No need for explicit peak condition as the slope guarantees convergence
            // At each step, check the mid element and its next neighbor to decide which half to continue searching in
            // If mid element is less than its next neighbor, the peak lies to the right (ascending slope)
            // If mid element is greater than its next neighbor, the peak lies to the left or is the mid element itself (descending slope or peak)


            int left = 0, right = arr.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < arr[mid + 1])
                    left = mid + 1; // Ascending slope
                else
                    right = mid;    // Descending slope or peak
            }

            return left; // or right, since left == right


        }
    }
}