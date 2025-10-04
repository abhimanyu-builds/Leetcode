using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using System.IO;
using System.Xml.Linq;

namespace Leetcode.Strategies.MergeSortedArrays
{
    [StrategyExport(
        ProblemType.MergeSortedArrays,
        name: "O(n) Reverse Merge",
        IsInPlace = true,
        HasDuplicates = false)]
    public class ReverseMergeSolution : IProblemSolution<MergeSortedArraysInput, int[]>
    {
        public int[] Solve(MergeSortedArraysInput input)
        {

            //Submission: https://leetcode.com/problems/merge-sorted-array/submissions/1790694331

            //Analysis:
            // Problem constraint: nums1 must be modified in-place to contain the merged result. It has trailing zeros to accommodate nums2.
            // If m == 0, copy nums2 directly into nums1
            // If n == 0, return nums1, nothing to merge from nums2
            // Use three pointers, i for nums1, j for nums2, k for the end of merged array in nums1
            // m and n define logical boundaries, not physical array lengths:
            //      m : how many elements in nums1 are valid and should be merged
            //      n : how many elements in nums2 are valid
            // measuring lengths directly risk misaligning merge boundaries

            var (nums1, m, nums2, n) = (input.Nums1, input.M, input.Nums2, input.N);

            if (n == 0) return nums1;
            if (m == 0)
            {
                for (int ix = 0; ix < n; ix++)
                    nums1[ix] = nums2[ix];
                return nums1;
            }

            int i = m - 1, j = n - 1, k = m + n - 1;

            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
            }

            return nums1;
        }
    }
}