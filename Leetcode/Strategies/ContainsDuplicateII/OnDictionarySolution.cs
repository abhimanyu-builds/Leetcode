using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;

namespace Leetcode.Strategies.ContainsDuplicateII
{
    [StrategyExport(
        ProblemType.ContainsDuplicateII,
        name: "O(n) Dictionary",
        IsInPlace = false,
        HasDuplicates = false)]
    public class OnDictionarySolution : IProblemSolution<ContainsDuplicateInput, bool>
    {
        public bool Solve(ContainsDuplicateInput input)
        {

            //Submission: https://leetcode.com/problems/contains-duplicate-ii/submissions/1776629115/

            //Analysis:
            //  Use a dictionary to store the last index of each number.
            //  For each number, check if it exists in the dictionary. If it does, check the difference between the current index and the last index.
            //      If the difference is less than k, return true.

            var (nums, k) = (input.Numbers, input.K);
            Dictionary<int, int> lookup = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (lookup.TryGetValue(nums[i], out int lastIndex))
                {
                    if (i - lastIndex <= k) { return true; }
                }
                lookup[nums[i]] = i;
            }
            return false;
        }
    }
}