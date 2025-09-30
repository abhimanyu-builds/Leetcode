using Leetcode.Interfaces;
using Leetcode.Metadata;

namespace Leetcode.Strategies.MaxConsecutive1s
{
    [StrategyExport(
        ProblemType.MaxConsecutive1s,
        name: "O(n) Stateful Traversal",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnStatefulTraversalScanSolution : IProblemSolution<int[], int>
    {
        public int Solve(int[] nums)
        {

            //Submission: https://leetcode.com/problems/max-consecutive-ones/submissions/1780819158/
            int maxCount = 0, currentCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    currentCount++;
                    maxCount = Math.Max(maxCount, currentCount);
                }
                else
                {
                    currentCount = 0;
                }
            }
            return maxCount;
        }
    }
}
