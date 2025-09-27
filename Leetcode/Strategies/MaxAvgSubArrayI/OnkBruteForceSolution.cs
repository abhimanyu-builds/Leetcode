using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.MaxAvgSubArrayI
{
    [StrategyExport(
        ProblemType.MaxAvgSubArrayI,
        name: "O(nk) Brute force",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnkBruteForceSolution : IProblemSolution<MaxAvgSubArrayInput, double>
    {
        public double Solve(MaxAvgSubArrayInput input)
        {

            //Submission: Time Limit Exceeded            125 / 127 testcases passed

            var (nums, k) = (input.Numbers, input.K ?? 1);
            if (nums.Length < k) return 0;
            
            double maxAvg = double.MinValue;            // To handle negative numbers when Math.Max(maxAvg, avg)
            for (int i = 0; i <= nums.Length - k; i++)
            {
                double sum = 0;
                for (int j = i; j < i + k; j++)
                {
                    sum += nums[j];
                }
                double avg = sum / k;
                maxAvg = Math.Max(maxAvg, avg);
            }

            return maxAvg;
        }
    }
}