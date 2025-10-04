namespace Leetcode.Models
{
    public class MergeSortedArraysInput(int[] nums1, int m, int[] nums2, int n = 0)
    {
        public int[] Nums1 { get; init; } = nums1;
        public int M { get; init; } = m;
        public int[] Nums2 { get; init; } = nums2;
        public int N { get; init; } = n;

        public override string ToString()
        {
            return $"{string.Join(",", Nums1)} | {M} | {string.Join(",", Nums2)} | {N}";
        }
    }

}