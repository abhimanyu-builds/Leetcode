using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies.SearchInsertPosition
{
    public class OnStatefulTraversalScanSolution : IProblemSolution<SearchInsertPositionInput, int>
    {
        public int Solve(SearchInsertPositionInput input)
        {

            //Submission: https://leetcode.com/problems/search-insert-position/submissions/1781792326/

            var (nums, target) = (input.Numbers, input.Target);

            if (nums.Length == 0) return 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target) { return i; }
            }
            return nums.Length;
        }
    }
}