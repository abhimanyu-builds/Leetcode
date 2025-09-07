using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies
{
    public class TwoSumSortedSolution : IProblemSolution<TwoSumSortedInput, int[]>
    {
        public int[] Solve(TwoSumSortedInput input)
        {

            //Submission: https://leetcode.com/submissions/detail/1762007111/

            //Analysis: 
            //array is sorted - in non-decreasing order.
            //return indices+1, not direct indices.
            //no duplicates
            //need not account for scenario with no solution.

            //Approach: 
            //track indices. if sum is more than target, window must reduce. else increase
            //for loop or while for readability
            //only extremes as starting indices will work.
            //taking random starting indices might not as valid pairs might fall outside the window

            //trivial example test case: [10, 20, 30, 40, 50, 60];
            //example target 100. result for 40,60 []
            var (numbers, target) = (input.Numbers, input.Target);
            int left = 0, right = numbers.Length - 1;
            while (numbers[left] + numbers[right] != target && left < right)
            {
                if (numbers[left] + numbers[right] < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return [left + 1, right + 1];

        }
    }
}