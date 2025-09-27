using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.MaxAvgSubArrayI
{
    [StrategyExport(
        ProblemType.MaxAvgSubArrayI,
        name: "O(n) Sliding Window",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnSlidingWindowSolution : IProblemSolution<MaxAvgSubArrayInput, double>
    {
        public double Solve(MaxAvgSubArrayInput input)
        {

            //Submission: https://leetcode.com/problems/maximum-average-subarray-i/submissions/1779692648/

            var (nums, k) = (input.Numbers, input.K ?? 1);
            if (nums.Length < k) return 0;
            double result = 0;      // Initial value 0/double.MinValue doesn't affect correctness since the first window's average is computed and assigned before comparisons begin

            double sum = 0;
            for (int i = 0; i < k; i++) { sum += nums[i]; }
            result = sum / k;        //avg = (j - 1) / j * avg + (double)nums[j - 1] / j; // rolling average - numerically unstable and incorrect

            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i] - nums[i - k];     //rolling sum
                result = Math.Max(result, sum / k);
            }
            return result;
        }
    }
}