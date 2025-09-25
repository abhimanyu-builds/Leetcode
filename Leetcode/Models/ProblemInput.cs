using Leetcode.Metadata;

namespace Leetcode.Models
{
    public record ProblemMetadata(ProblemType Type, DensityLevel Density, PivotDepth? Pivot = null);// Nullable for non-rotated problems

    public abstract class ProblemInput<TCollection>
    {
        public TCollection Numbers { get; init; }
        public int Target { get; init; }

        protected ProblemInput(TCollection numbers, int target)
        {
            Numbers = numbers;
            Target = target;
        }

        public override string ToString() => $"[{string.Join(", ", Numbers)}], Target: {Target}";
    }
    public class RemoveElementInput : ProblemInput<int[]>
    {
        public RemoveElementInput(int[] numbers, int target) : base(numbers, target) { }
    }

    public class TwoSumInput : ProblemInput<int[]>
    {
        public TwoSumInput(int[] numbers, int target) : base(numbers, target) { }
    }

    public class TwoSumSortedInput : ProblemInput<int[]>
    {
        public TwoSumSortedInput(int[] numbers, int target) : base(numbers, target) { }
    }

    public class ThreeSumInput : ProblemInput<List<int>>
    {
        public ThreeSumInput(List<int> numbers, int target) : base(numbers, target) { }
    }
    public class RotatedArrayInput : ProblemInput<int[]>
    {
        public RotatedArrayInput(int[] numbers, int target) : base(numbers, target) { }
    }
    public class MaxAverageSubArrayInput : ProblemInput<int[]>
    {
        public MaxAverageSubArrayInput(int[] numbers, int target) : base(numbers, target) { }
    }
    public class SearchInsertPositionInput : ProblemInput<int[]>
    {
        public SearchInsertPositionInput(int[] numbers, int target) : base(numbers, target) { }
    }
}