using Leetcode.Interfaces;
using Leetcode.Models;
using System.Drawing;

namespace Leetcode.Strategies.ContainsDuplicateII
{
    public class OnHashsetSolution : IProblemSolution<ContainsDuplicateInput, bool>
    {
        public bool Solve(ContainsDuplicateInput input)
        {

            //Submission: https://leetcode.com/problems/contains-duplicate-ii/submissions/1776622000/
            //Analysis:
            //  Use a HashSet to store elements within the last k indices.
            //  For each i, check if nums[i] is already in the set:
            //      If yes: duplicate found within range → return true.
            //      else: add nums[i] to the set.
            //  If the window size exceeds k, remove nums[i - k] to maintain the window. Remove it unconditionally once the window exceeds size k


            var (nums, k) = (input.Numbers, input.K);
            HashSet<int> seen = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(nums[i])) { return true; }            // check for duplicates before adding
                seen.Add(nums[i]);
                if (i - k >= 0) seen.Remove(nums[(int)(i - k)]);        // i-k>0 skips removal at i=k, which is when the sliding should begin
            }
            return false;
        }
    }
}