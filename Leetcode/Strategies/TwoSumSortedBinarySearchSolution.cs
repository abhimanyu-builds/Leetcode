using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies
{
    public class TwoSumSortedBinarySearchSolution : IProblemSolution<TwoSumSortedInput, int[]>
    {
        public Task<int[]> SolveAsync(TwoSumSortedInput input)
        {

            //Submission: https://leetcode.com/submissions/detail/1762022829/

            //Analysis: 
            //array is sorted - in non-decreasing order.
            //return indices+1, not direct indices.
            //no duplicates
            //need not account for scenario with no solution.

            //Approach: 
            //track indices. if sum is more than target, window must reduce. else increase
            //for -ve numbers, it should be opposite
            //use binary search for complement
            //for loop or while for readability

            //trivial example test case: [10, 20, 30, 40, 50, 60];
            //example target 100. result for 40,60 []
            var (numbers, target) = (input.Numbers, input.Target);
            for (int i = 0; i < numbers.Length - 1; i++) //n-1 as last element cannot have a complement
            {
                if (i > 0 && numbers[i] == numbers[i - 1]) continue;    //skip duplicates
                int complement = target - numbers[i];
                int left = i + 1, right = numbers.Length - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2; //mathematically equivalent but computationally safer, avoids overflow for large numbers
                    if (numbers[mid] == complement)
                    {
                        return Task.FromResult<int[]>([i + 1, mid + 1]);
                    }
                    else if (numbers[mid] < complement)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            // Unreachable line due to problem constraints (exactly one solution guaranteed).
            return Task.FromResult<int[]>([-1, -1]);
        }
    }
}