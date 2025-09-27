using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.MaxConsecutive1s
{
    [StrategyExport(
        ProblemType.MaxConsecutive1s,
        name: "O(n) Manual index manipulation",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnManualIndexManipulationScanSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/max-consecutive-ones/submissions/1780820393/

            int maxCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;
                if (nums[i] != 1) continue;
                while (i < nums.Length && nums[i] == 1)
                {
                    count++;
                    i++;
                }
                maxCount = Math.Max(maxCount, count);
            }

            return maxCount;
        }
    }
}