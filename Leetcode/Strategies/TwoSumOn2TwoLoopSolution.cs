using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies
{
    public class TwoSumOn2TwoLoopSolution : IProblemSolution<TwoSumInput, int[]>
    {
        public int[] Solve(TwoSumInput input)
        {

            //Submission: //https://leetcode.com/submissions/detail/1761606991/

            //Analysis:
            //nums can have -ve/0/+ve numbers in any order
            //find 2 elements whose sum equals target
            //indices need to be returned - any order is okay

            //Approach: 
            //For each element, find its complement in the rest of the array. Can check to match target-element or element+complement=target

            //Solution:
            //Outer i loop runs n-1 times and inner j loop runs n-i-1 for each iteration of i. 
            //Worst-case time complexity -> O(n^2) Quadratic time complexity (algorithm slows down as input size grows)

            var (nums, target) = (input.Numbers, input.Target);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        //Exactly 1 solution => return after finding a match
                        return [i, j];
                    }
                }
            }
            //Exactly 1 solution => Always has solution => ideally never get executed. Only for compilation
            return [0, 0];
        }
    }
}