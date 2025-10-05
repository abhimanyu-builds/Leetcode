using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.FindMountainPeak
{
    [StrategyExport(
        ProblemType.FindMountainPeak,
        name: "O(n) Brute Force Linear Search for First Peak",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnLinearScanFirstPeakSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] arr)
        {

            //Submission: https://leetcode.com/problems/peak-index-in-a-mountain-array/submissions/1792473823/

            // Analysis:
            // Linear search to find the peak element in a mountain array
            // Time Complexity: O(n), Space Complexity: O(1)
            // Assumes valid mountain array input as per problem constraints
            // For each element check if it is greater than its neighbors

            if (arr.Length < 3) return -1; // If invalid mountain array, but per constraints this won't happen

            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
                    return i;
            }

            return -1; // If not found, but unreachable for valid mountain array per constraints

        }
    }
}