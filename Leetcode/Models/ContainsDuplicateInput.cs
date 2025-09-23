namespace Leetcode.Models
{
    public class ContainsDuplicateInput : ProblemInput<int[]>
    {
        public int? K { get; init; } // For II and III
        public int? T { get; init; } // For III

        public ContainsDuplicateInput(int[] numbers, int? k = null, int? t = null)
            : base(numbers, target: 0) // Target is unused, but required by base
        {
            K = k;
            T = t;
        }

        public override string ToString()
        {
            var baseStr = base.ToString();
            var kStr = K.HasValue ? $", K: {K}" : "";
            var tStr = T.HasValue ? $", T: {T}" : "";
            return $"{baseStr}{kStr}{tStr}";
        }
    }

    public class MaxAvgSubArrayInput : ContainsDuplicateInput
    {
        public MaxAvgSubArrayInput(int[] numbers, int k) : base(numbers, k) { }
    }
}