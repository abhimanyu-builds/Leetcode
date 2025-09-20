using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies.ContainsDuplicateI
{
    public class On2BruteForceSolution : IProblemSolution<ContainsDuplicateInput, bool>
    {
        public bool Solve(ContainsDuplicateInput input)
        {

            //Submission: Timed out on larger inputs

            var (nums, target) = (input.Numbers, input.Target);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j]) { return true; }
                }
            }
            return false;
        }
    }
}